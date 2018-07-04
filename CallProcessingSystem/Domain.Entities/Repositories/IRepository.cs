using System;
using System.Linq.Expressions;

namespace Domain.Entities.Repositories
{
    public interface IRepository<TEntity> : IReader<TEntity>
    {
        /// <summary>
        ///     Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        void Add(TEntity t);

        /// <summary>
        ///     Update object or create a new object to database.
        /// </summary>
        /// <param name="entity">Specified the object to save.</param>
        void AddOrUpdate(TEntity entity);

        /// <summary>
        ///     Update object or create a new object to database.
        /// </summary>
        /// <param name="entity">Specified the object to save.</param>
        void AddOrUpdate(TEntity entity, Expression<Func<TEntity, object>> identifierExpression);

        /// <summary>
        ///     Update database row using object's current values. Not update navigation properties.
        /// </summary>
        /// <param name="t">Specified a existing modified object.</param>
        /// <param name="keys">Specified object key or keys(for composite primary key)</param>
        void UpdateSimpleProperties(TEntity t, params object[] keys);

        void DetectChanges(TEntity entity);

        /// <summary>
        ///     Attaches existing entity to context
        /// </summary>
        /// <param name="entity">Specified the object to attach.</param>
        void Attach(TEntity entity);

        /// <summary>
        ///     Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>
        void Remove(TEntity t);
    }
}