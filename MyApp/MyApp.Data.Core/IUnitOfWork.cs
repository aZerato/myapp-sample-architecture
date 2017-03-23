namespace MyApp.Data.Core
{
    using System;
    using System.Data.Entity;

    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        void Commit();

        /// <summary>
        /// 
        /// </summary>
        void CommitAndRefreshChanges();

        /// <summary>
        /// 
        /// </summary>
        void RollbackChanges();

        /// <summary>
        /// 
        /// </summary>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void SetModified<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
