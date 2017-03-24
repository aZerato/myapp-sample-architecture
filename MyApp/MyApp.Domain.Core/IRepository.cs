namespace MyApp.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The Repository Interface.
    /// </summary>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Add an entity to context.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Remove an entity to context.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Update an entity to context.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Get an entity by id from context.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>Expected entity.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Get entities from context.
        /// </summary>
        /// <returns>Expected entities.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get entities from context.
        /// </summary>
        /// <typeparam name="TResult">Expected return objects.</typeparam>
        /// <param name="selectBuilder">Custom select expression.</param>
        /// <returns>Expected entities.</returns>
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selectBuilder);

        /// <summary>
        /// Get entities from context.
        /// </summary>
        /// <typeparam name="TResult">Expected return objects.</typeparam>
        /// <param name="selectBuilder">Custom select expression.</param>
        /// <param name="predicate">Custom filter expression.</param>
        /// <returns>Expected entities.</returns>
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get entities and count from context.
        /// </summary>
        /// <typeparam name="TResult">Expected return objects.</typeparam>
        /// <param name="selectBuilder">Custom select expression.</param>
        /// <param name="predicate">Custom filter expression.</param>
        /// <returns>Expected entities and count.</returns>
        Tuple<IEnumerable<TResult>, int> GetAllAndCount<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate);
    }
}
