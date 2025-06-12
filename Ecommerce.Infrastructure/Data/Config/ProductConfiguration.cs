using Ecommerce.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(30);
       builder.HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "T-Shirt", Description = "Comfortable cotton t-shirt", Price = 19.99m, CategoryId = 2 },
                new Product { Id = 4, Name = "Jeans", Description = "Stylish denim jeans", Price = 49.99m, CategoryId = 2 },
                new Product { Id = 5, Name = "Fiction Book", Description = "Engaging fiction novel", Price = 14.99m, CategoryId = 3 }
            );

        }
    }
}
