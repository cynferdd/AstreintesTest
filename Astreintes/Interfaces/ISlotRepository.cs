using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ISlotRepository : IRepository<Slot>
    {
        IEnumerable<Slot> GetByAssigneeId(int id);

        IEnumerable<Slot> GetByPeriod(DateTime begin, DateTime end);

        IEnumerable<Slot> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end);
    }
}
