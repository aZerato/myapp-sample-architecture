namespace MyApp.Domain.Core
{
    /// <summary>
    /// Contract for Entity.
    /// </summary>
    /// <typeparam name="T">Type of identifier.</typeparam>
    public interface IBaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the Identifier.
        /// </summary>
        T ID { get; set; }
    }
}
