namespace MyApp.Domain.DTO
{
    using Core;

    /// <summary>
    /// SampleData DTO class.
    /// </summary>
    public class SampleDataDTO : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public string Status { get; set; }
    }
}
