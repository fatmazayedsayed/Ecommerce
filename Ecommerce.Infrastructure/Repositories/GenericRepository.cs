using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context;
        public GenericRepository(AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
           
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var entity = await query.FirstOrDefaultAsync(x=>EF.Property<int>(x,"Id")==id);
            
            return   entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {

            _context.Entry(entity).State=EntityState.Modified;
            
        }
    }
}
