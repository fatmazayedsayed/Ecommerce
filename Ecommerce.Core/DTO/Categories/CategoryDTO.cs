 

namespace Ecommerce.Core.DTO.Categories
{
    public record CategoryDTO(string Name, string Description);
    public record CategoryUpdateDTO(string Name, string Description, int Id) : CategoryDTO(Name, Description);


}