using Ecommerce.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Data.Config
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PhotoName).IsRequired().HasMaxLength(30);
            builder.HasData(
                    new Photo { Id = 1, PhotoName = "Laptop", ProductId = 1 },
                    new Photo { Id = 2, PhotoName = "Mobile", ProductId = 2 },
                    new Photo { Id = 3, PhotoName = "Tablet", ProductId = 3 },
                    new Photo { Id = 4, PhotoName = "Headphone", ProductId = 4 },
                    new Photo { Id = 5, PhotoName = "Smartwatch", ProductId = 5 }
                );

        }
    }
}
