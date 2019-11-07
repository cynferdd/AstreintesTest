using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISlotRepository : IRepository<Slot>
    {
        Task<IEnumerable<Slot>> GetByAssigneeId(int id);

        Task<IEnumerable<Slot>> GetByPeriod(DateTime begin, DateTime end);

        Task<IEnumerable<Slot>> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end);
    }
}
