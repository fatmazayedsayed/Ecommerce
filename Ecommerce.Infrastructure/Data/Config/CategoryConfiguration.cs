using Ecommerce.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic items" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and garments" },
                new Category { Id = 3, Name = "Books", Description = "Various genres of books" }
            );
        }
    }
}
