/// <summary>
/// SampleData Repository.
/// </summary>
public interface ISampleDataRepository
    : IRepository<SampleData>
{
}

/// <inheritdoc cref="ISampleDataRepository"/>
public class SampleDataRepository
    : Repository<SampleData>,
      ISampleDataRepository
{
    public SampleDataRepository(MyAppDbContext dbContext) 
        : base(dbContext)
    {
    }
}