using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        public IProductRepository Products { get; }

        public ICategoryRepository Categories { get; }

        public IPhotoRepository Photos { get; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Photos = new PhotoRepository(_context);

        }

        public Task SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
