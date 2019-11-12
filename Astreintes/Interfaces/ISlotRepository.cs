using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Repository dedicated to slots
    /// </summary>
    public interface ISlotRepository : IRepository<Slot>
    {
        /// <summary>
        /// Get a list of slots based on the assignee Id
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <returns>List of slots for the given Assignee</returns>
        Task<IEnumerable<Slot>> GetByAssigneeId(int id);

        /// <summary>
        /// Get a list of slots within a period
        /// </summary>
        /// <param name="begin">begin date</param>
        /// <param name="end">end date</param>
        /// <returns>list of slots within the defined period</returns>
        Task<IEnumerable<Slot>> GetByPeriod(DateTime begin, DateTime end);

        /// <summary>
        /// Get a list of slots for an assignee, within a period
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <param name="begin">Begin Date</param>
        /// <param name="end">End Date</param>
        /// <returns>List pf slots for an assignee, within a period</returns>
        Task<IEnumerable<Slot>> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end);
    }
}
