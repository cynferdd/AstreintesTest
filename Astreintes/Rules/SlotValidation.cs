﻿using Entities;
using Interfaces;
using System;

namespace Rules
{
    /// <summary>
    /// Rules defining a slot validation
    /// </summary>
    public class SlotValidation : ISlotValidation
    {
        /// <summary>
        /// In a slot, the beginning date must be set before the end date
        /// </summary>
        /// <param name="slot">slot to test</param>
        /// <returns>are the dates valid ?</returns>
        public bool CheckDateValidity(Slot slot)
        {
            return slot != null && DateTime.Compare(slot.BeginDate, slot.EndDate) < 0;
        }

        public bool CheckValidation(Slot slot)
        {
            return 
                slot != null &&
                slot.Assignee != null &&
                CheckDateValidity(slot);
        }
    }
}