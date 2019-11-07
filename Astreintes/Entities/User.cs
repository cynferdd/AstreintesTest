using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// User representaion
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
    }
}
