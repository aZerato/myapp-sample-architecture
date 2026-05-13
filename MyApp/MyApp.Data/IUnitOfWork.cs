/// <summary>
/// UnitOfWork interface of our MyAppDbContext.
/// </summary>
public interface IUnitOfWork
    : IDisposable
{
    /// <summary>
    /// Sample Data Repository.
    /// </summary>
    ISampleDataRepository SampleDataRepository { get; }

    /// <summary>
    /// Commit Changes.
    /// </summary>
    void SaveChanges();

    /// <summary>
    /// Commit Changes Async.
    /// </summary>
    /// <returns>Number of changes.</returns>
    Task<int> SaveChangesAsync();
}