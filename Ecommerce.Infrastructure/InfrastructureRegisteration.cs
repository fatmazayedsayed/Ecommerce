// Ecommerce.Infrastructure/Config/InfrastructureRegistration.cs
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Services;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories.Service;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register DbContext with validation
            var connectionString = configuration.GetConnectionString("EcommerceDb");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "Database connection string 'EcommerceDb' not found in configuration.");
            }

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
#if DEBUG
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, LogLevel.Information);
#endif
            });

            // Register other services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IImageManagementService, ImageManagementService>();

            // Configure wwwroot file provider
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            if (!Directory.Exists(wwwrootPath))
            {
                Directory.CreateDirectory(wwwrootPath);
            }
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(wwwrootPath));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}