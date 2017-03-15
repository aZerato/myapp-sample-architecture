namespace MyApp.Domain.SampleModule.Services
{
    /// <summary>
    /// Basic Sample Service.
    /// </summary>
    public class BasicSampleService : IBasicSampleService
    {
        #region ----- Fields -----
        #endregion

        #region ----- Constructor -----
        #endregion

        #region ----- Implement IBasicSampleService -----

        /// <summary>
        /// <see cref="IBasicSampleService.IsAvailable()"/> 
        /// </summary>
        /// <param name="token"><see cref="IBasicSampleService.IsAvailable()"</param>
        /// <returns><see cref="IBasicSampleService.IsAvailable()"</returns>
        bool IBasicSampleService.IsAvailable()
        {
            return true;
        }

        #endregion
    }
}
