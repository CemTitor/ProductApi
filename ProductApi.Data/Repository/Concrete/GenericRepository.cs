using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Context;
using ProductApi.Data.Repository.Abstract;

namespace ProductApi.Data.Repository.Concrete
{
    ///Other parts of the project perform database operations through this class instead of directly accessing the database.
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext Context;
        private DbSet<Entity> entities;

        public GenericRepository(AppDbContext dbContext)
        {
            Context = dbContext;
            entities = Context.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public async Task InsertAsync(Entity entity)
        {
            await entities.AddAsync(entity);
        }

        public void RemoveAsync(Entity entity)
        {
            var column = entity.GetType().GetProperty("IsDeleted");
            if (column is not null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            }
            else
            {
                entities.Remove(entity);
            }
        }

        public void Update(Entity entity)
        {
            entities.Update(entity);
        }
    }
}