using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WinYoungUI.Data.Repository;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Abstract
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        protected GenericRepository<TEntity> Repository;
        protected Service(GenericRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public void Insert(TEntity entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.ModifiedTime = DateTime.Now;
            Repository.Insert(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            Repository.Update(entityToUpdate);
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return Repository.GetQueryable(filter, orderBy);
        }

        public async Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await Task.FromResult(Repository.GetQueryable(filter, orderBy));
        }

        public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return Repository.GetWithRawSql(query, parameters);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }

        public void Delete(object id)
        {
            Repository.Delete(id);
        }

        public void Delete(TEntity entityToDelete)
        {
            Repository.Delete(entityToDelete);
        }

        #region Dispose

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
