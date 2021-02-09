using Core.DataAccess.EntityRepository.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityRepository.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public readonly DbContext _dbContext;
        public EntityRepositoryBase()
        {
            _dbContext = new TContext();

            Query = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Query { get; set; }

        public DbSet<TEntity> Entities => _dbContext.Set<TEntity>();

        private void AddInclude(Expression<Func<TEntity, object>>[] includes)
        {
            foreach (var include in includes)
                Query = Query.Include(include);
        }

        public bool Add(TEntity entity)
        {
            Entities.Add(entity);
            return Commit();
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public bool CreateBulk(List<TEntity> entities)
        {
            Entities.AddRange(entities);
            return Commit();
        }

        public bool Delete(TEntity entity)
        {
            Entities.Remove(entity);
            return Commit();
        }

        public bool Update(TEntity entity)
        {
            Entities.Update(entity);
            return Commit();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            AddInclude(includes);
            return Query.Where(expression).FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includes)
        {
            AddInclude(includes);
            if (expression == null)
                return Entities.ToList();
            else
                return Entities.Where(expression).ToList();
        }   
    }
}
