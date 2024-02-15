using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<TModel, TKey> : IGenericRepository<TModel, TKey>
                                                      where TModel : class
                                                      where TKey : struct
    {
        private readonly DBContext _context;
        private readonly DbSet<TModel> _dbSet;
        public GenericRepository(DBContext dbcontext)
        {
            _context = dbcontext;
            _dbSet = _context.Set<TModel>();
        }

        public bool IsExist(Expression<Func<TModel, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        TModel IGenericRepository<TModel, TKey>.Create(TModel entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        void IGenericRepository<TModel, TKey>.Delete(TKey id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        IQueryable<TModel> IGenericRepository<TModel, TKey>.Find(Expression<Func<TModel, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        IQueryable<TModel> IGenericRepository<TModel, TKey>.GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        TModel? IGenericRepository<TModel, TKey>.GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        TModel IGenericRepository<TModel, TKey>.Update(TKey id, TModel entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }

}
