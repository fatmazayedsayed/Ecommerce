using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection; 

namespace Ecommerce.Infrastructure
{
    public static class InfrastructureRegisteration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped(typeof( IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped< IProductRepository, ProductRepository>();
            //services.AddScoped< ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IPhotoRepository, PhotoRepository>();    

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
