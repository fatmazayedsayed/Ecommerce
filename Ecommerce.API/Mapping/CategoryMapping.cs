using AutoMapper;
using Ecommerce.Core.DTO.Categories;
using Ecommerce.Core.Entities.Product;

namespace Ecommerce.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
                
        }
    }
}
