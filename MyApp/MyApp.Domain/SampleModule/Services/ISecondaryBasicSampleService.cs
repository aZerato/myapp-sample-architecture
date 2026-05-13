using MyApp.Domain.DTO;

/// <summary>
/// Basic Sample Service Interfaces.
/// </summary>
public interface ISecondaryBasicSampleService
{
    /// <summary>
    /// Return a SampleData by ID.
    /// </summary>
    /// <param name="ID">The entity ID.</param>
    /// <returns>The expected entity.</returns>
    SampleDataDTO GetById(int ID);

    /// <summary>
    /// Return all SampleData. 
    /// </summary>
    /// <returns>Return all SampleData.</returns>
    IEnumerable<SampleDataDTO> GetAll();

    /// <summary>
    /// Add Sample.
    /// </summary>
    /// <param name="sampleDataDTO"></param>
    void Add(SampleDataDTO sampleDataDTO);
}