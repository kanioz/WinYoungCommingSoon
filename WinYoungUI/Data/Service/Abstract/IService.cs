using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WinYoungUI.Data.Service.Abstract
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        void Delete(object id);

        void Delete(TEntity entityToDelete);
    }
}
