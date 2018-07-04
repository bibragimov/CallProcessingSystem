using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;
using Domain.Entities.Repositories;

namespace Domain.EF.Repositories
{
    public class EfRepository<TEntity> : EfReader<TEntity>, IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void AddOrUpdate(TEntity entity)
        {
            Set.AddOrUpdate(entity);
        }

        public void AddOrUpdate(TEntity entity, Expression<Func<TEntity, object>> identifierExpression)
        {
            Set.AddOrUpdate(identifierExpression, entity);
        }

        public void UpdateSimpleProperties(TEntity entity, params object[] keys)
        {
            Context.Entry(Set.Find(keys)).CurrentValues.SetValues(entity);
        }

        public void DetectChanges(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Attach(TEntity entity)
        {
            Set.Attach(entity);
        }

        public void Remove(TEntity entity)
        {
            Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Set.Remove(entity);
        }
    }
}