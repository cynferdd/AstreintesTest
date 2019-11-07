using Entities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class SlotRepository : ISlotRepository
    {
        public Slot Create(Slot obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Slot obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slot> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slot> GetByAssigneeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slot> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slot> GetByPeriod(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Slot Update(Slot obj)
        {
            throw new NotImplementedException();
        }
    }
}
