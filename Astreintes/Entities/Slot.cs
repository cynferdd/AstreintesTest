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
        public User Assignee { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
