namespace Ecommerce.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepositiry { get; }
        public IPhotoRepository PhotoRepositiry { get; }
        public IProductRepositiry ProductRepositiry { get; }
    }
}
