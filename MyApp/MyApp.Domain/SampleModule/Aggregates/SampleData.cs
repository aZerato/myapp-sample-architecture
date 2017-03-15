namespace MyApp.Domain.SampleModule.Aggregates
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// SampleData class.
    /// </summary>
    [Table("SampleData")]
    public class SampleData
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

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
