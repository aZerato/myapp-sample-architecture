using Microsoft.EntityFrameworkCore;

/// <summary>
/// MyApp DbContext implementation.
/// </summary>
public class MyAppDbContext 
    : DbContext
{
    /// <summary>
    /// CTOR.
    /// </summary>
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// SampleDatas DbSet.
    /// </summary>
    public DbSet<SampleData> SampleDatas { get; set; }
}