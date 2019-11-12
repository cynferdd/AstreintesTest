using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Slot entity used on the UI/API side
    /// </summary>
    public class SlotUI
    {
        /// <summary>
        /// Assignee Id. Used for creation or deletion
        /// </summary>
        public int AssigneeId { get; set; }

        /// <summary>
        /// Assignee representation (Name + timezone) used only when getting data
        /// </summary>
        public string AssigneeRepresentation { get; set; }

        /// <summary>
        /// Call duty begin date and time
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Call duty end date and time
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
