

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public interface IGenericRepository<TModel, TKey> where TModel : class
                                                      where TKey : struct
    {

        IQueryable<TModel> GetAll();
        TModel? GetById(TKey id);
        TModel Create(TModel entity);
        TModel Update(TKey id, TModel entity);
        void Delete(TKey id);
        bool IsExist(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate);
    }
}
