namespace MyApp.Data.Core
{
    using Domain.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The Repository Implementation.
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region ---- Fields ----

        /// <summary>
        /// The current UoW.
        /// </summary>
        private readonly IUnitOfWork _currentUoW;

        #endregion

        #region ---- Constructor ----

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UoW");
            }

            this._currentUoW = unitOfWork;
        }

        #endregion

        #region ---- Repository Implementation ----

        /// <summary>
        /// <see cref="IRepository{TEntity}.Add(TEntity)"/> 
        /// </summary>
        /// <param name="entity"><see cref="IRepository{TEntity}.Add(TEntity)"/> </param>
        public virtual void Add(TEntity entity)
        {
            this._currentUoW.CreateSet<TEntity>().Add(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Remove(TEntity)"/>
        /// </summary>
        /// <param name="entity"><see cref="IRepository{TEntity}.Remove(TEntity)"/></param>
        public virtual void Remove(TEntity entity)
        {
            var oSet = this._currentUoW.CreateSet<TEntity>();

            oSet.Attach(entity);
            oSet.Remove(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Update(TEntity)"/>
        /// </summary>
        /// <param name="entity"><see cref="IRepository{TEntity}.Update(TEntity)"/></param>
        public virtual void Update(TEntity entity)
        {
            this._currentUoW.SetModified(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Get(int)"/>
        /// </summary>
        /// <param name="id"><see cref="IRepository{TEntity}.Get(int)"/></param>
        /// <returns></returns>
        public virtual TEntity Get(int id)
        {
           return this._currentUoW.CreateSet<TEntity>().Find(id);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.GetAll()"/>
        /// </summary>
        /// <returns><see cref="IRepository{TEntity}.GetAll()"/></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._currentUoW.CreateSet<TEntity>().AsEnumerable();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.GetAll(Expression, Expression)"/>
        /// </summary>
        /// <typeparam name="TResult"><see cref="IRepository{TEntity}.GetAll(Expression, Expression)"/></typeparam>
        /// <param name="selectBuilder"><see cref="IRepository{TEntity}.GetAll(Expression, Expression)"/></param>
        /// <param name="predicate"><see cref="IRepository{TEntity}.GetAll(Expression, Expression)"/></param>
        /// <returns><see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/></returns>
        public virtual IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate)
        {
            return this._currentUoW.CreateSet<TEntity>().Where(predicate).Select(selectBuilder).AsEnumerable();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/>
        /// </summary>
        /// <typeparam name="TResult"><see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/></typeparam>
        /// <param name="selectBuilder"><see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/></param>
        /// <param name="predicate"><see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/></param>
        /// <returns><see cref="IRepository{TEntity}.GetAllAndCount(Expression, Expression)"/></returns>
        public virtual Tuple<IEnumerable<TResult>, int> GetAllAndCount<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate)
        {
            var oSet = this._currentUoW.CreateSet<TEntity>();

            var filtered = oSet.Where(predicate).Select(selectBuilder).AsEnumerable();
            var count = oSet.Where(predicate).Select(selectBuilder).Count();

            return new Tuple<IEnumerable<TResult>, int>(filtered, count);
        }

        #endregion
    }
}
