using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// SampleData class.
/// </summary>
[Table("SampleData")]
public class SampleData
{
    [Key]
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the Title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Status.
    /// </summary>
    public SampleDataStatus Status { get; set; }
}