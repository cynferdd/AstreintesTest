using DAL;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    /// <summary>
    /// Slot repository => link with the DAL
    /// </summary>
    public class SlotRepository : ISlotRepository
    {
        private readonly EFContext context;

        public SlotRepository(EFContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Slot creation
        /// </summary>
        /// <param name="obj">Slot to create</param>
        /// <returns>Slot created</returns>
        public async Task<Slot> Create(Slot obj)
        {
            // we must reference the user stored in the EF DBSet
            obj.Assignee = await context.Users.FindAsync(obj?.Assignee?.Id ?? -1);
            var added = await context.Slots.AddAsync(obj).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return added.Entity;
        }

        /// <summary>
        /// Deleting a slot
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Slot obj)
        {
            // we must reference the user stored in the EF DBSet
            obj.Assignee = await context.Users.FindAsync(obj?.Assignee?.Id ?? -1);
            var deleted = context.Slots.Remove(obj);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return deleted.Entity != null;
        }

        /// <summary>
        /// Getting all slots
        /// </summary>
        /// <returns>list of all slots</returns>
        public async Task<IEnumerable<Slot>> GetAll()
        {
            return await context.Slots.Include(s => s.Assignee).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Getting a list of slots linked to an assignee
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <returns>list of slots</returns>
        public async Task<IEnumerable<Slot>> GetByAssigneeId(int id)
        {
            return await context.Slots
                .Include(s => s.Assignee)
                .Where(s => s.Assignee != null && s.Assignee.Id == id)
                .OrderBy(s => s.BeginDate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Getting a list of slots corresponding to a period of time and an assignee
        /// </summary>
        /// <param name="id">Assignee Id</param>
        /// <param name="begin">Begin date</param>
        /// <param name="end">end date</param>
        /// <returns>list of corresponding slots</returns>
        public async Task<IEnumerable<Slot>> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end)
        {
            return await context.Slots
                .Include(s => s.Assignee)
                .Where(s => 
                    s.Assignee != null && 
                    s.Assignee.Id == id &&
                    DateTime.Compare(s.BeginDate,begin)>=0 &&
                    DateTime.Compare(s.EndDate, end) <= 0)
                .OrderBy(s => s.BeginDate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Getting a list of slots corresponding to a period of time
        /// </summary>
        /// <param name="begin">Begin date and time</param>
        /// <param name="end">End date and time</param>
        /// <returns>list of slots</returns>
        public async Task<IEnumerable<Slot>> GetByPeriod(DateTime begin, DateTime end)
        {
            return await context.Slots
                .Include(s => s.Assignee)
                .Where(s =>
                    DateTime.Compare(s.BeginDate, begin) >= 0 &&
                    DateTime.Compare(s.EndDate, end) <= 0)
                .OrderBy(s => s.BeginDate)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
