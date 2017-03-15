namespace MyApp.Domain.SampleModule.Aggregates
{
    using System.ComponentModel;

    /// <summary>
    /// Sample data status.
    /// </summary>
    public enum SampleDataStatus
    {
        [Description("Default")]
        Default,

        [Description("Activated")]
        Activated,

        [Description("Down")]
        Down,
    }
}
