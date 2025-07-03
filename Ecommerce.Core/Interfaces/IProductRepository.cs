using Ecommerce.Core.DTO.Products;
using Ecommerce.Core.DTO.Sharing;
using Ecommerce.Core.Entities.Product; 

namespace Ecommerce.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDTO productDto);
        Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task DeleteAsync(Product product);
        Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams);

    }
}
