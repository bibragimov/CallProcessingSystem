using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Entities.Repositories
{
    public interface IReader<TEntity>
    {
        /// <summary>
        ///     Start building query to database.
        ///     Objects will not be added to change tracker.
        /// </summary>
        /// <returns>Querable collection</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        ///     Start building query to database.
        ///     Objects will be added to change tracker. This method can cause performace promblem.
        /// </summary>
        /// <returns>Querable collection</returns>
        IQueryable<TEntity> GetWithTracking();

        /// <summary>
        ///     Look for an existing object.
        ///     Changes of object will be tracked.
        /// </summary>
        /// <param name="keys">Specidied object key or keys(for composite primary key)</param>
        /// <returns>Object or null</returns>
        TEntity Find(params object[] keys);

        /// <summary>
        ///     Look for an existing object.
        ///     Changes of object will be tracked.
        /// </summary>
        /// <param name="predicate">Find expression</param>
        /// <returns>Object or null</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Reload entity properties from database
        /// </summary>
        void Refresh(TEntity entity);

        bool IsExists(object id);

        bool IsExists(Expression<Func<TEntity, bool>> predicate);
    }
}