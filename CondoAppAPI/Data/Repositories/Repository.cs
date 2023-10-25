using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly CondoAppContext _context;

        protected DbSet<TEntity> Entity => _context.Set<TEntity>();

        public Repository(CondoAppContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null)
        {
            IQueryable<TEntity> query = Entity;

            if (includes != null)
                query = includes(query) as IQueryable<TEntity>;

            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null)
        {
            IQueryable<TEntity> query = Entity;

            if (includes != null)
                query = includes(query) as IQueryable<TEntity>;

            return await query.Where(where).ToListAsync();
        }


        public async Task<bool> Exists(Expression<Func<TEntity, bool>> where)
        {
            return await Entity.AnyAsync(where);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> where = null)
        {
            return await Entity.CountAsync(where);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            Entity.Add(entity);

            await SaveChanges();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityEntry<TEntity> entry = _context.Entry(entity);

            Entity.Attach(entity);

            entry.State = EntityState.Modified;

            await SaveChanges();

            return entity;
        }

        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
