using Microsoft.EntityFrameworkCore;
using SmartFin.Db;
using SmartFin.Entities;

namespace SmartFin.Service
{
    public class PostrgresRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly SmartFinDbContext context;

        private readonly DbSet<T> _dbSet;

        public PostrgresRepository()
        {
            this.context = new SmartFinDbContext();
            _dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
           
                await _dbSet.AddAsync(entity);
                await context.SaveChangesAsync();             
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.guid == id);
            if (user != null)
            {
                _dbSet.Remove(user);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.guid == id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
