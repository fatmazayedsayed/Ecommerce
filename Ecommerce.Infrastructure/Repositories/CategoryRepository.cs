using Ecommerce.Core.Entities.Product;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepositiry : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepositiry(AppDBContext context) : base(context)
        {
        }
    }
}
