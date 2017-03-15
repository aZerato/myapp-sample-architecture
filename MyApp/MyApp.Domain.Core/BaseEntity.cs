namespace MyApp.Domain.Core
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntity<T> : IBaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the Identifier.
        /// </summary>
        [Key]
        public T ID { get; set; }
    }
}
