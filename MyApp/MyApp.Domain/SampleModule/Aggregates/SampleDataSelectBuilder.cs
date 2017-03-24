namespace MyApp.Domain.SampleModule.Aggregates
{
    using DTO;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// SampleData SelectBuilders.
    /// </summary>
    public static class SampleDataSelectBuilder
    {
        /// <summary>
        /// Transform SampleData to DTO.
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<SampleData, SampleDataDTO>> SelectSampleData()
        {
            return data => new SampleDataDTO
            {
                ID = data.ID,
                Title = data.Title,
                Status = data.Status.ToString()
            };
        }
    }
}
