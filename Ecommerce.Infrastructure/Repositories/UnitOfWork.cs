using AutoMapper;
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Services;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public UnitOfWork(AppDBContext context, IMapper mapper, IImageManagementService imageManagementService)
        {
            _context = context;
            CategoryRepositiry = new CategoryRepositiry(context);
            ProductRepositiry = new ProductRepositiry(_context, mapper, imageManagementService);
            PhotoRepositiry = new PhotoRepository(context);
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }

        public ICategoryRepository CategoryRepositiry { get; }
        public IPhotoRepository PhotoRepositiry { get; }
        public IProductRepositiry ProductRepositiry { get; }

     }
}
