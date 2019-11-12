using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// On Call Duty slot
    /// </summary>
    public class Slot
    {
        /// <summary>
        /// User assigned to the call duty
        /// </summary>
        public User Assignee { get; set; }

        /// <summary>
        /// Begin date and time (UTC)
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// End date and time (UTC)
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
