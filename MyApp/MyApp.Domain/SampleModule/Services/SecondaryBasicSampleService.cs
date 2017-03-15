namespace MyApp.Domain.SampleModule.Services
{
    using CrossCutting;
    using DTO;

    /// <summary>
    /// Secondary Basic Sample Service.
    /// </summary>
    public class SecondaryBasicSampleService : ISecondaryBasicSampleService
    {
        #region ----- Fields -----

        /// <summary>
        /// CacheManager instance.
        /// </summary>
        private ICacheManager cacheManager;

        #endregion

        #region ----- Constructor -----

        /// <summary>
        /// Default SecondaryBasicSampleService constructor.
        /// </summary>
        public SecondaryBasicSampleService (
                ICacheManager cacheManager
        ) {
            this.cacheManager = cacheManager;
        }

        #endregion

        #region ----- Implement IBasicSampleService -----

        /// <summary>
        /// <see cref="ISecondaryBasicSampleService.GetSampleData(int)"/> 
        /// </summary>
        /// <param name="token"><see cref="ISecondaryBasicSampleService.GetSampleData(int)"</param>
        /// <returns><see cref="ISecondaryBasicSampleService.GetSampleData(int)"</returns>
        SampleDataDTO ISecondaryBasicSampleService.GetSampleData(int ID)
        {

            // TODO
            return new SampleDataDTO();
        }

        #endregion
    }
}
