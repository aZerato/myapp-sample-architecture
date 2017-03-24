namespace MyApp.Domain.SampleModule.Services
{
    using DTO;
    using System.Collections.Generic;

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
        SampleDataDTO GetSampleData(int ID);

        /// <summary>
        /// Return all SampleData. 
        /// </summary>
        /// <returns>Return all SampleData.</returns>
        IEnumerable<SampleDataDTO> GetAllSampleData();
    }
}
