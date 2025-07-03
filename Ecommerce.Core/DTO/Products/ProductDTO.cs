

using Ecommerce.Core.DTO.Photos;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Core.DTO.Products
{
    public record ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public virtual List<PhotoDTO> Photos { get; set; }
        public string CategoryName { get; set; }

    }

   
    public record AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public IFormFileCollection Photo { get; set; }
        public int CategoryId { get; set; }

    }

    public record UpdateProductDTO : AddProductDTO
    {
        public int Id { get; set; }

    }

}