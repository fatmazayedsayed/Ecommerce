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
            builder.Property(x => x.ImageName).IsRequired().HasMaxLength(30);
            builder.HasData(
                    new Photo { Id = 1, ImageName = "Laptop", ProductId = 1 },
                    new Photo { Id = 2, ImageName = "Mobile", ProductId = 2 },
                    new Photo { Id = 3, ImageName = "Tablet", ProductId = 3 },
                    new Photo { Id = 4, ImageName = "Headphone", ProductId = 4 },
                    new Photo { Id = 5, ImageName = "Smartwatch", ProductId = 5 }
                );

        }
    }
}
