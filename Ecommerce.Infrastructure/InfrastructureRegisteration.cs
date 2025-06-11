using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Ecommerce.Infrastructure
{
    public static class InfrastructureRegisteration
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof( IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped< IProductRepository, ProductRepository>();
            //services.AddScoped< ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IPhotoRepository, PhotoRepository>();    

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //apply db context
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EcommerceDb")));
            return services;
        }
    }
}
