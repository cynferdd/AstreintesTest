using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// User representaion
    /// </summary>
    public class User
    {
        /// <summary>
        /// user id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time zone
        /// </summary>
        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
    }
}
