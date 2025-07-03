using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepositiry { get; }
        public IPhotoRepository PhotoRepositiry { get; }
        public IProductRepositiry ProductRepositiry { get; }
    }
}
