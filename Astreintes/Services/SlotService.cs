using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository repository;
        private readonly ISlotValidation validation;

        public SlotService(ISlotRepository slotRepository, ISlotValidation slotValidation)
        {
            repository = slotRepository;
            validation = slotValidation;
        }

        public async Task<Slot> Create(Slot obj)
        {
            Slot result = new Slot();
            if (validation.CheckValidation(obj))
            {
                result = await repository.Create(obj);
            }
            return result;
        }

        public async Task<bool> Delete(Slot obj)
        {
            
            return await repository.Delete(obj);
            
        }

        public async Task<Slot> Update(Slot obj)
        {
            Slot result = new Slot();
            if (validation.CheckValidation(obj))
            {
                result = await repository.Update(obj);
            }
            return result;
        }

        public async Task<IEnumerable<Slot>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<IEnumerable<Slot>> GetByAssigneeId(int id)
        {
            return await repository.GetByAssigneeId(id);
        }

        public async Task<IEnumerable<Slot>> GetByAssigneeIdAndPeriod(int id, DateTime begin, DateTime end)
        {
            return await repository.GetByAssigneeIdAndPeriod(id, begin, end);
        }

        public async Task<IEnumerable<Slot>> GetByPeriod(DateTime begin, DateTime end)
        {
            return await repository.GetByPeriod(begin, end);
        }

        
    }
}
