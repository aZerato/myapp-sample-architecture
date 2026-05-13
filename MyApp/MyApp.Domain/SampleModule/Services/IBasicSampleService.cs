namespace MyApp.Domain.SampleModule.Services;

/// <summary>
/// Interface for manage Basic Service.
/// </summary>
public interface IBasicSampleService
{
    /// <summary>
    /// Verify if service is available.
    /// </summary>
    /// <returns>Is available or not.</returns>
    bool IsAvailable();
}