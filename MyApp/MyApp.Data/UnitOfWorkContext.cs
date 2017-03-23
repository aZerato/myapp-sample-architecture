namespace MyApp.Data
{
    using Core;
    using Domain.SampleModule.Aggregates;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// EF context for MyApp Database.
    /// </summary>
    public class UnitOfWorkContext : DbContext, IUnitOfWork
    {
        #region ---- Constructor ----

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public UnitOfWorkContext()
            : base("MyAppConnectionString")
        {

        }

        #endregion

        #region ---- properties ----
        
        public IDbSet<SampleData> SampleDatas { get; set; }

        #endregion

        #region ---- UnitOfWork Implementation ----

        /// <summary>
        /// <see cref="IUnitOfWork.Commit"/>
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.CommitAndRefreshChanges"/>
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            // Change all Entities in change tracker as 'unchanged' state
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <summary>
        /// <see cref="IUnitOfWork.RollbackChanges"/>
        /// </summary>
        public void RollbackChanges()
        {
            var valid = false;

            while (valid)
            {
                try
                {
                    this.SaveChanges();
                    valid = true;
                }
                catch (DBConcurrencyException)
                {
                    valid = false;
                }
            }
        }

        /// <summary>
        /// <see cref="IUnitOfWork.CreateSet"/>
        /// </summary>
        public IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void SetModified<TEntity>(TEntity entity)
            where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        #endregion
    }
}
