namespace MyApp.Domain.SampleModule.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
}
