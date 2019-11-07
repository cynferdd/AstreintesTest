using Entities;
using System;

namespace Interfaces
{
    public interface ISlotValidation : IValidation<Slot>
    {
        /// <summary>
        /// In a slot, the beginning date must be set before the end date
        /// </summary>
        /// <param name="slot">slot to test</param>
        /// <returns>are the dates valid ?</returns>
        bool CheckDateValidity(Slot slot);
    } 
}
