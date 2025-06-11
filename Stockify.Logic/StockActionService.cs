using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic
{
    /// <summary>
    /// Service class for managing stock actions including retrieval, addition, updates, and deletion.
    /// </summary>
    public class StockActionService : IStockActionService
    {
        private readonly StockifyContext _context;
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockActionService"/> class.
        /// </summary>
        /// <param name="context">The database context for Stockify.</param>
        /// <param name="productService">The product service to interact with product data.</param>
        public StockActionService(StockifyContext context, IProductService productService)
        {
            _context = context;
            this.productService = productService;
        }

        /// <summary>
        /// Retrieves all stock actions with related product and order line data.
        /// </summary>
        /// <returns>A list of all stock actions.</returns>
        public async Task<List<StockAction>> GetAllAsync() =>
            await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).ToListAsync();

        /// <summary>
        /// Retrieves a stock action by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the stock action.</param>
        /// <returns>The stock action if found; otherwise, null.</returns>
        public async Task<StockAction?> GetByIdAsync(int id) =>
            await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).FirstOrDefaultAsync(sa => sa.Id == id);

        /// <summary>
        /// Retrieves a stock action by the associated order line ID.
        /// </summary>
        /// <param name="id">The order line ID.</param>
        /// <returns>The stock action if found; otherwise, null.</returns>
        public async Task<StockAction?> GetByOrderLineIdAsync(int id) =>
            await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == id);

        /// <summary>
        /// Adds a new stock action and updates product stock accordingly.
        /// Throws an exception if product not found or reduction quantity exceeds available stock.
        /// </summary>
        /// <param name="action">The stock action to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the product does not exist or reduction is invalid.</exception>
        public async Task AddAsync(StockAction action)
        {
            var product = await productService.GetByIdAsync(action.ProductId);
            if (product == null)
            {
                throw new Exception("Product for stock action not found");
            }

            if (action.Type == StockActionType.Reduction && action.Quantity > product.AvailableStock)
            {
                throw new Exception("Reductie mag niet groter zijn dan beschikbare voorraad.");
            }

            _context.StockActions.Add(action);
            product.LastStockAction = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            await productService.RecalculateStock(action.ProductId);
        }

        /// <summary>
        /// Deletes a stock action by its ID if it exists.
        /// </summary>
        /// <param name="id">The ID of the stock action to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(int id)
        {
            var action = await _context.StockActions.FindAsync(id);
            if (action != null)
            {
                _context.StockActions.Remove(action);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves a paged list of stock actions for a product, with sorting options.
        /// </summary>
        /// <param name="productId">The product ID to filter stock actions.</param>
        /// <param name="pageNumber">The current page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="sortBy">The field to sort by (type, quantity, createdAt).</param>
        /// <param name="ascending">Sort direction: true for ascending, false for descending.</param>
        /// <returns>A paginated result containing stock actions.</returns>
        public async Task<PaginatedResult<StockAction>> GetPagedAsync(int productId, int pageNumber, int pageSize, string sortBy, bool ascending)
        {
            var query = _context.StockActions.Include(sa => sa.OrderLine).Where(sa => sa.ProductId == productId);
            query = (sortBy.ToLower(), ascending) switch
            {
                ("type", true) => query.OrderBy(sa => sa.Type),
                ("type", false) => query.OrderByDescending(sa => sa.Type),
                ("quantity", true) => query.OrderBy(sa => sa.Quantity),
                ("quantity", false) => query.OrderByDescending(sa => sa.Quantity),
                ("createdat", true) => query.OrderBy(sa => sa.CreatedAt),
                ("createdat", false) => query.OrderByDescending(sa => sa.CreatedAt),
                _ => query.OrderByDescending(sa => sa.CreatedAt)
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<StockAction>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Adds a reservation stock action for the specified order line.
        /// Updates the available and total stock for the product of the stockaction
        /// </summary>
        /// <param name="orderLine">The order line to add a reservation for.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddReservation(OrderLine orderLine)
        {
            var product = await _context.Products.Include(p => p.StockActions).FirstOrDefaultAsync(p => p.Id == orderLine.ProductId);
            var action = new StockAction
            {
                ProductId = orderLine.ProductId,
                Type = StockActionType.Reservation,
                Quantity = orderLine.Quantity,
                OrderLineId = orderLine.Id
            };
            if (product != null)
            {
                product.LastStockAction = DateTime.UtcNow;
            }
            _context.StockActions.Add(action);
            await _context.SaveChangesAsync();
            await productService.RecalculateStock(action.ProductId);
        }

        /// <summary>
        /// Adds reservation stock actions for a list of order lines.
        /// </summary>
        /// <param name="orderLines">The list of order lines.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddReservations(List<OrderLine> orderLines)
        {
            foreach (var orderLine in orderLines)
            {
                await AddReservation(orderLine);
            }
        }

        /// <summary>
        /// Updates an existing reservation stock action for the given order line.
        /// Updates the available and total stock for the product of the stockaction
        /// </summary>
        /// <param name="orderLine">The order line to update reservation for.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateReservation(OrderLine orderLine)
        {
            var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
            if (action != null)
            {
                var oldProductId = action.ProductId;
                var newProductId = orderLine.ProductId;

                action.Quantity = orderLine.Quantity;
                action.ProductId = orderLine.ProductId;

                _context.StockActions.Update(action);

                var newProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == newProductId);
                if (newProduct != null)
                    newProduct.LastStockAction = DateTime.UtcNow;

                // TODO: Update LastStockAction for old product if needed

                await _context.SaveChangesAsync();
                await productService.RecalculateStock(oldProductId);
                await productService.RecalculateStock(newProductId);
            }
        }

        /// <summary>
        /// Updates reservation stock actions for a list of order lines.
        /// Updates the available and total stock for the product of each orderline
        /// </summary>
        /// <param name="orderLines">The order lines to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateReservations(List<OrderLine> orderLines)
        {
            foreach (var orderLine in orderLines)
            {
                var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
                if (action == null)
                {
                    await AddReservation(orderLine);
                }
                else
                {
                    await UpdateReservation(orderLine);
                }
            }
        }

        /// <summary>
        /// Updates reservation stock actions for all order lines in the specified order.
        /// </summary>
        /// <param name="order">The order containing the order lines.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateReservations(Order order)
        {
            if (order == null || order.OrderLines == null || !order.OrderLines.Any())
            {
                return;
            }
            await UpdateReservations(order.OrderLines.ToList());
        }

        /// <summary>
        /// Deletes the reservation stock action associated with the specified order line.
        /// Updates the available and total stock for the product of the stockaction
        /// </summary>
        /// <param name="orderLine">The order line whose reservation to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteReservation(OrderLine orderLine)
        {
            var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id);
            if (action != null)
            {
                _context.StockActions.Remove(action);
                await _context.SaveChangesAsync();
                await productService.RecalculateStock(action.ProductId);
            }
        }

        /// <summary>
        /// Deletes reservation stock actions for a list of order lines.
        /// </summary>
        /// <param name="orderLines">The list of order lines whose reservations to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteReservations(List<OrderLine> orderLines)
        {
            foreach (var orderLine in orderLines)
            {
                await DeleteReservation(orderLine);
            }
        }
    }
}



/*





// Interface
using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class StockActionService : IStockActionService
{
    private readonly StockifyContext _context;
    private readonly IProductService productService;
    public StockActionService(StockifyContext context, IProductService productService)
    {
        _context = context;
        this.productService = productService;
    }

    public async Task<List<StockAction>> GetAllAsync() => await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).ToListAsync();

    public async Task<StockAction?> GetByIdAsync(int id) => await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).FirstOrDefaultAsync(sa => sa.Id == id);

    public async Task<StockAction?> GetByOrderLineIdAsync(int id) => await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == id);
    public async Task AddAsync(StockAction action)
    {

        var product = await productService.GetByIdAsync(action.ProductId);

        if(product==null)
        {
            throw new Exception("product for stockaction not found");
        }

        if (action.Type == StockActionType.Reduction)
        {            
            if(action.Quantity>product.AvailableStock)
            {
                throw new Exception("Reductie mag niet groter zijn dan beschikbare voorraad.");
            }            
        }        
        _context.StockActions.Add(action);
        product.LastStockAction = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        await productService.RecalculateStock(action.ProductId);
    }

    public async Task DeleteAsync(int id)
    {
        var action = await _context.StockActions.FindAsync(id);
        if (action != null)
        {
            _context.StockActions.Remove(action);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<PaginatedResult<StockAction>> GetPagedAsync(int productId, int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.StockActions.Include(sa=>sa.OrderLine).Where(sa => sa.ProductId == productId);
        query = (sortBy.ToLower(), ascending) switch
        {
            ("type", true) => query.OrderBy(sa => sa.Type),
            ("type", false) => query.OrderByDescending(sa => sa.Type),
            ("quantity", true) => query.OrderBy(sa => sa.Quantity),
            ("quantity", false) => query.OrderByDescending(sa => sa.Quantity),
            ("createdat", true) => query.OrderBy(sa => sa.CreatedAt),
            ("createdat", false) => query.OrderByDescending(sa => sa.CreatedAt),
            _ => query.OrderByDescending(sa => sa.CreatedAt)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<StockAction>
        {
            Items = items,
            TotalCount = totalCount
        };
    }

    public async Task AddReservation(OrderLine orderLine)
    {
        var product = await _context.Products.Include(p => p.StockActions).FirstOrDefaultAsync(p => p.Id == orderLine.ProductId);
        var action = new StockAction
        {
            ProductId = orderLine.ProductId,
            Type = StockActionType.Reservation,
            Quantity = orderLine.Quantity,
            OrderLineId = orderLine.Id
        };
        product.LastStockAction = DateTime.UtcNow;
        _context.StockActions.Add(action);
        await _context.SaveChangesAsync();
        await productService.RecalculateStock(action.ProductId);
    }

    public async Task AddReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            await AddReservation(orderLine);
        }
    }

    //bestaande orderline, product en/of quantity aangepast
    public async Task UpdateReservation(OrderLine orderLine)
    {
        var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
        if (action != null)
        {
            var oldProductId = action.ProductId; // Store old product ID for stock recalculation
            var newProductId = orderLine.ProductId;

            action.Quantity = orderLine.Quantity;// Update quantity ID if changed
            action.ProductId = orderLine.ProductId; // Update product ID if changed

            _context.StockActions.Update(action);

            var newProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == newProductId);
            if (newProduct != null) newProduct.LastStockAction = DateTime.UtcNow;

            //todo update laststockaction old product

            await _context.SaveChangesAsync();
            await productService.RecalculateStock(oldProductId);
            await productService.RecalculateStock(newProductId);
        }
    }

    public async Task UpdateReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
            if (action == null)
            {
                await AddReservation(orderLine);
            }
            else
            {
                await UpdateReservation(orderLine);
            }
        }
    }

    public async Task UpdateReservations(Order order)
    {
        if (order == null || order.OrderLines == null || !order.OrderLines.Any())
        {
            return; // No lines to update
        }
        await UpdateReservations(order.OrderLines.ToList()); // Update all order lines in the order
    }

    public async Task DeleteReservation(OrderLine orderLine)
    {
        var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id); // && sa.Type == StockActionType.Reservation);
        if (action != null)
        {
            _context.StockActions.Remove(action);
            await _context.SaveChangesAsync();
            await productService.RecalculateStock(action.ProductId);
        }
    }

    public async Task DeleteReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            await DeleteReservation(orderLine);
        }
    }
}
*/