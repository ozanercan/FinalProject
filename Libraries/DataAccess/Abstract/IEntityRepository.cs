using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> exp);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> exp = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
