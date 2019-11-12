using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Service for slots
    /// </summary>
    public interface ISlotService
    {
        /// <summary>
        /// Get all slots
        /// </summary>
        /// <returns>List of all slots</returns>
        Task<IEnumerable<Slot>> GetAll();

        /// <summary>
        /// Get slots for an assignee
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <returns>list of slots for an assignee</returns>
        Task<IEnumerable<Slot>> GetByAssigneeId(int id);

        /// <summary>
        /// Get slots for a period
        /// </summary>
        /// <param name="begin">Begin date</param>
        /// <param name="end">End date</param>
        /// <returns>List of slots for a period of time</returns>
        Task<IEnumerable<Slot>> GetByPeriod(DateTime begin, DateTime end);

        /// <summary>
        /// Get slots for a period of time and an assignee
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <param name="begin">Begin date</param>
        /// <param name="end">end date</param>
        /// <returns>List of slots for a given assignee and a period</returns>
        Task<IEnumerable<Slot>> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end);

        /// <summary>
        /// Create a Slot
        /// </summary>
        /// <param name="obj">Slot to create</param>
        /// <returns>Created slot</returns>
        Task<Slot> Create(Slot obj);

        /// <summary>
        /// Deleting a slot
        /// </summary>
        /// <param name="obj">Slot to delete</param>
        /// <returns>Was the deletion done ?</returns>
        Task<bool> Delete(Slot obj);
    }
}
