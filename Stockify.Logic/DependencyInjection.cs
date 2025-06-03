using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockify.Data;
using Stockify.Logic.Services;
namespace Stockify.Logic;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StockifyContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("Stockify.Data")));
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderLineService, OrderLineService>();
        services.AddScoped<IOrderActionService, OrderActionService>();
        services.AddScoped<IStockActionService, StockActionService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddSingleton<IToastService, ToastService>();
        return services;
    }
}
