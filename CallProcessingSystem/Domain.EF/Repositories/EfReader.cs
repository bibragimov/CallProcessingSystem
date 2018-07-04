using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities.Repositories;

namespace Domain.EF.Repositories
{
    public abstract class EfReader<TEntity> : IReader<TEntity>
        where TEntity : class
    {
        protected readonly DbContext Context;

        protected EfReader(DbContext context)
        {
            Context = context;
        }

        protected DbSet<TEntity> Set
        {
            get { return Context.Set<TEntity>(); }
        }

        public IQueryable<TEntity> Get()
        {
            return Set.AsNoTracking();
        }

        public IQueryable<TEntity> GetWithTracking()
        {
            return Set;
        }

        public TEntity Find(params object[] keys)
        {
            return Set.Find(keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public void Refresh(TEntity entity)
        {
            Context.Entry(entity).Reload();
        }

        public bool IsExists(object id)
        {
            var parameterExpr = Expression.Parameter(typeof(TEntity));
            var idPropExpr = Expression.Property(parameterExpr, "Id");
            var idExpr = Expression.Constant(id, typeof(object));
            var eqExpr = Expression.Equal(idPropExpr, idExpr);
            var expr = Expression.Lambda<Func<TEntity, bool>>(eqExpr, parameterExpr);

            return Get()
                .Any(expr);
        }

        public bool IsExists(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Any(predicate);
        }
    }
}