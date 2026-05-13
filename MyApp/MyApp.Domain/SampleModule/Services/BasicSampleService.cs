namespace MyApp.Domain.SampleModule.Services;

/// <inheritdoc cref="IBasicSampleService"/>
public class BasicSampleService : IBasicSampleService
{
    /// <inheritdoc cref="IBasicSampleService.IsAvailable()"/>
    bool IBasicSampleService.IsAvailable()
    {
        return true;
    }
}