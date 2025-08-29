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
        services.AddDbContext<StockifyContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sql => {
                        sql.MigrationsAssembly("Stockify.Data");
                        sql.EnableRetryOnFailure(
                                maxRetryCount: 5,                          // retry up to 5 times
                                maxRetryDelay: TimeSpan.FromSeconds(10),   // wait up to 10s between retries
                                errorNumbersToAdd: null                    // retry on all transient SQL errors
                        );
                        }));
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderLineService, OrderLineService>();
        services.AddScoped<IOrderActionService, OrderActionService>();
        services.AddScoped<IStockActionService, StockActionService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IToastService, ToastService>();
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}
