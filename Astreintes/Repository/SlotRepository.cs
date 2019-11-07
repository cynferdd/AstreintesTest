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
            var added = await context.Slots.AddAsync(obj).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return added.Entity;
        }

        public async Task<bool> Delete(Slot obj)
        {
            var deleted = context.Slots.Remove(obj);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return deleted.Entity != null;
        }

        public async Task<IEnumerable<Slot>> GetAll()
        {
            return await context.Slots.Include(s => s.Assignee).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Slot>> GetByAssigneeId(int id)
        {
            return await context.Slots
                .Include(s => s.Assignee)
                .Where(s => s.Assignee != null && s.Assignee.Id == id)
                .OrderBy(s => s.BeginDate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

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

        public async Task<Slot> Update(Slot obj)
        {
            var updated = context.Slots.Update(obj);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return updated.Entity;
        }
    }
}
