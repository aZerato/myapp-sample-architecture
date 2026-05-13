namespace MyApp.Domain.SampleModule.Services;

/// <inheritdoc cref="IBasicSampleService"/>
public class BasicSampleService : IBasicSampleService
{
    /// <inheritdoc cref="IBasicSampleService.IsAvailable()"/>
    public bool IsAvailable()
    {
        return true;
    }
}