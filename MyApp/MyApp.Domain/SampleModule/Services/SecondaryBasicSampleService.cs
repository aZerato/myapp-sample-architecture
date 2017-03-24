namespace MyApp.Domain.SampleModule.Services
{
    using Aggregates;
    using Core;
    using CrossCutting;
    using DTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Secondary Basic Sample Service.
    /// </summary>
    public class SecondaryBasicSampleService : ISecondaryBasicSampleService
    {
        #region ----- Fields -----

        /// <summary>
        /// Repository<SampleData> instance.
        /// </summary>
        private IRepository<SampleData> sampleDataRepository;

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
                IRepository<SampleData> sampleDataRepository,
                ICacheManager cacheManager
        ) {
            this.sampleDataRepository = sampleDataRepository;
            this.cacheManager = cacheManager;
        }

        #endregion

        #region ----- Implement IBasicSampleService -----

        /// <summary>
        /// <see cref="ISecondaryBasicSampleService.GetSampleData(int)" />
        /// </summary>
        /// <param name="ID"><see cref="ISecondaryBasicSampleService.GetSampleData(int)" /></param>
        /// <returns><see cref="ISecondaryBasicSampleService.GetSampleData(int)" /></returns>
        SampleDataDTO ISecondaryBasicSampleService.GetSampleData(int ID)
        {
            var data = this.sampleDataRepository.Get(ID);
            
            return new SampleDataDTO() {
                ID = data.ID,
                Status = EnumExtensions.GetDescription(data.Status),
                Title = data.Title
            };
        }

        /// <summary>
        /// <see cref="ISecondaryBasicSampleService.GetAllSampleData()"/> 
        /// </summary>
        /// <returns><see cref="ISecondaryBasicSampleService.GetAllSampleData()"/></returns>
        IEnumerable<SampleDataDTO> ISecondaryBasicSampleService.GetAllSampleData()
        {
            return this.sampleDataRepository.GetAll(SampleDataSelectBuilder.SelectSampleData());
        }

        #endregion
    }
}
