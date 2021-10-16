using Microsoft.Extensions.DependencyInjection;
using RDO.Core.Interfaces.Repositories;
using RDO.Core.Interfaces.Services;
using RDO.Infrastructure.Repositories;
using RDO.ServiceInterface;

namespace RDO.WebApi
{
    public static class ServiceCollectionSetup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }

    }
}

