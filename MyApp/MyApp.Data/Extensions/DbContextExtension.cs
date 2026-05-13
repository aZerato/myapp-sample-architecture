using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// Extension methods for create SQL Server DbContext.
/// </summary>
public static class DbContextExtension
{
    /// <summary>
    /// Instantiation of the DbContext with UoW/Repo patterns.
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void InitDatabase(this IHostApplicationBuilder builder)
    {
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContextPool<MyAppDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}