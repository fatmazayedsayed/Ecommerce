 

namespace Ecommerce.Core.DTO.Products
{
    public record ProductDTO(string Name, string Description, int CategoryId);
    public record ProductUpdateDTO(string Name, string Description, int CategoryId , int Id) : ProductDTO(Name, Description, CategoryId);


}