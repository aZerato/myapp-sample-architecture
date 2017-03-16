namespace MyApp.Domain.SampleModule.Aggregates
{
    using Core;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// SampleData class.
    /// </summary>
    [Table("SampleData")]
    public class SampleData : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public SampleDataStatus Status { get; set; }
    }
}
