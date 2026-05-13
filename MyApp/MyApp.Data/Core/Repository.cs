using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

/// <inheritdoc cref="IRepository{TEntity}"/>
public class Repository<TEntity> 
    : IRepository<TEntity>
    where TEntity : class
{
    readonly DbContext _dbContext;
    readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Default Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    /// <inheritdoc cref="IRepository{TEntity}.Add(TEntity)"/>
    public virtual void Add(TEntity entity)
    {
        _dbContext.Add(entity);;
    }

    /// <inheritdoc cref="IRepository{TEntity}.Remove(TEntity)"/>
    public virtual void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    /// <inheritdoc cref="IRepository{TEntity}.Update(TEntity)"/>
    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetById(object)"/>
    public virtual TEntity GetById(object id)
    {
        return _dbSet.Find(id)!;
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAll()"/>
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAll{TResult}(Expression{Func{TEntity, TResult}})"/>
    public virtual IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selectBuilder)
    {
        return _dbSet.Select(selectBuilder).ToList();
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAll{TResult}(Expression{Func{TEntity, TResult}}, Expression{Func{TEntity, bool}})"/>
    public virtual IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).Select(selectBuilder).ToList();
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAllAndCount{TResult}(Expression{Func{TEntity, TResult}}, Expression{Func{TEntity, bool}})"/>
    public virtual Tuple<IEnumerable<TResult>, int> GetAllAndCount<TResult>(Expression<Func<TEntity, TResult>> selectBuilder, Expression<Func<TEntity, bool>> predicate)
    {
        var filtered = _dbSet.Where(predicate).Select(selectBuilder).ToList();
        var count = filtered.Count;

        return new Tuple<IEnumerable<TResult>, int>(filtered, count);
    }
}