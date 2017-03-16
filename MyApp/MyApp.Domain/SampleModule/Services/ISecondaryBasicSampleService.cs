namespace MyApp.Domain.SampleModule.Services
{
    using DTO;

    /// <summary>
    /// Interfaces
    /// </summary>
    public interface ISecondaryBasicSampleService
    {
        /// <summary>
        /// Return a SampleData by ID.
        /// </summary>
        /// <param name="token"><see cref="ISecondaryBasicSampleService.GetSampleData(int)"</param>
        /// <returns><see cref="ISecondaryBasicSampleService.GetSampleData(int)"</returns>
        SampleDataDTO GetSampleData(int ID);
    }
}
