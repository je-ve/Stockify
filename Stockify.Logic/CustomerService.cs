using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly StockifyContext _context;

    public CustomerService(StockifyContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync(bool onlyActive = true)
    {
        if (onlyActive)
        {
            return await _context.Customers
            .Where(c => c.IsActive)
              .Include(c => c.CreatedBy)
              .Include(c => c.UpdatedBy)
              .ToListAsync();
        }

        return await _context.Customers
          .Include(c => c.CreatedBy)
          .Include(c => c.UpdatedBy)
          .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task AddAsync(Customer customer, string currentUserId)
    {
        customer.CreatedAt = DateTime.UtcNow;
        customer.CreatedById = currentUserId;
        customer.UpdatedAt = DateTime.UtcNow;
        customer.UpdatedById = currentUserId;

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer, string currentUserId)
    {
        customer.UpdatedAt = DateTime.UtcNow;
        customer.UpdatedById = currentUserId;
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    //Wanneer klant wordt verwijderd wordt deze functie uitgevoerd. 
    public async Task SetInactiveAsync(int id, string currentUserId)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            var order = await _context.Orders.Where(o => (o.CustomerId == id && o.Status == OrderStatus.Created)).FirstOrDefaultAsync();
            if (order != null) throw new Exception("Klanten met openstaande bestelling kunnen niet verwijderd worden");

            customer.IsActive = false; // Soft delete
            customer.UpdatedAt = DateTime.UtcNow;
            customer.UpdatedById = currentUserId;
            customer.Name = "Anoniem";
            customer.Email = "inactive@unknow.com";
            customer.Street = "Onbekend";
            customer.HouseNumber = "0";
            customer.City = "Onbekend";

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<PaginatedResult<Customer>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending, bool onlyActive = true)
    {
        var query = _context.Customers
        .Include(c => c.CreatedBy)
        .Include(c => c.UpdatedBy)
        .AsQueryable();

        if (onlyActive)
        {
            query = query.Where(c => c.IsActive); // assuming "Active" is a bool property
        }

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("name", true) => query.OrderBy(c => c.Name),
            ("name", false) => query.OrderByDescending(c => c.Name),
            ("email", true) => query.OrderBy(c => c.Email),
            ("email", false) => query.OrderByDescending(c => c.Email),
            ("city", true) => query.OrderBy(c => c.City),
            ("city", false) => query.OrderByDescending(c => c.City),
            ("createdby", true) => query.OrderBy(c => c.CreatedBy.UserName),
            ("createdby", false) => query.OrderByDescending(c => c.CreatedBy.UserName),
            ("createdat", true) => query.OrderBy(c => c.CreatedAt),
            ("createdat", false) => query.OrderByDescending(c => c.CreatedAt),
            ("updatedby", true) => query.OrderBy(c => c.UpdatedBy.UserName),
            ("updatedby", false) => query.OrderByDescending(c => c.UpdatedBy.UserName),
            ("updatedat", true) => query.OrderBy(c => c.UpdatedAt),
            ("updatedat", false) => query.OrderByDescending(c => c.UpdatedAt),
            _ => query.OrderBy(c => c.Name) // default
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Customer>
        {
            Items = items,
            TotalCount = totalCount
        };
    }

    public async Task<List<(string CustomerName, int TotalQuantity)>> GetTopCustomersAsync()
    {
        return await _context.OrderLines
            .Where(ol => ol.Order.Status == OrderStatus.Created || ol.Order.Status == OrderStatus.Delivered)
            .Select(ol => new
            {
                CustomerName = ol.Order.Customer.Name,
                Quantity = ol.Quantity
            })
            .GroupBy(x => x.CustomerName)
            .Select(g => new
            {
                CustomerName = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(10)
            .Select(x => new ValueTuple<string, int>(x.CustomerName, x.TotalQuantity))
            .ToListAsync();
    }


}
