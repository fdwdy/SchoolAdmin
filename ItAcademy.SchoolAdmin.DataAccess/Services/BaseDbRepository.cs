using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public abstract class BaseDbRepository<T> : IRepository<T>
        where T : class, IDbEntity
    {
        private readonly SchoolContext _db;
        private readonly DbSet<T> _dbSet;
        private T _dbEntity;

        public BaseDbRepository(SchoolContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public BaseDbRepository(SchoolContext db, DbSet<T> dbset)
        {
            _db = db;
            _dbSet = dbset;
        }

        public virtual void Create(T item)
        {
            _dbEntity = item;
            _dbEntity.Id = Guid.NewGuid().ToString();
            _dbSet.Add(_dbEntity);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(string id)
        {
            T entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var query = from item in _dbSet select item;
            return await query
                .SingleOrDefaultAsync(c => c.Id.Equals(
                    id, StringComparison.OrdinalIgnoreCase))
                .ConfigureAwait(false);
        }

        public Result Save()
        {
            _db.SaveChanges();
            return Result.Ok();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(T item)
        {
            _dbSet.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public abstract Task<bool> FindByName(string name);

        public abstract Task<IEnumerable<T>> SearchAsync(string query);
    }
}
