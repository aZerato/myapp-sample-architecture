/// <inheritdoc cref="IUnitOfWork"/>
public class UnitOfWork(MyAppDbContext context)
    : IUnitOfWork
{
    readonly MyAppDbContext _dbContext = context;

    /// <inheritdoc cref="IUnitOfWork.SampleRepository"/>
    public ISampleDataRepository SampleDataRepository =>
        field = new SampleDataRepository(_dbContext);

    /// <inheritdoc cref="IUnitOfWork.SaveChanges"/>
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    /// <inheritdoc cref="IUnitOfWork.SaveChangesAsync"/>
    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    bool disposed = false;

    /// <summary>
    /// IDisposable implementation.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    /// <summary>
    /// IDisposable implementation.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}