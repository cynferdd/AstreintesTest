using Entities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Mappers
{
    /// <summary>
    /// Mapping class for Slots
    /// </summary>
    public class SlotMapper : IMapper<Slot, SlotUI>
    {
        #region IMapper
        /// <summary>
        /// Mapping a slot into a slot ui
        /// </summary>
        /// <param name="obj">slot to map</param>
        /// <returns>corresponding slot ui</returns>
        public SlotUI Map(Slot obj)
        {
            return new SlotUI()
            {
                AssigneeId = obj?.Assignee.Id ?? -1,
                AssigneeRepresentation = GetAssigneeRepresentation(obj),
                BeginDate = obj?.BeginDate ?? DateTime.MinValue,
                EndDate = obj?.EndDate ?? DateTime.MaxValue
            };
        }

        

        /// <summary>
        /// mapping a slot ui into a slot
        /// </summary>
        /// <param name="obj">slot ui to map</param>
        /// <returns>corresponding slot</returns>
        public Slot Map(SlotUI obj)
        {
            Slot result = new Slot();
            if (obj != null)
            {
                // The Assignee will be replaced with the real user within the repository
                result.Assignee = new User() { Id = obj.AssigneeId };
                result.BeginDate = obj.BeginDate;
                result.EndDate = obj.EndDate;
            }
            return result;
        }

        /// <summary>
        /// Mapping a list of slots into a list of Slot UI
        /// </summary>
        /// <param name="listObj">list of slots to map</param>
        /// <returns>list of mapped slot Uis</returns>
        public IEnumerable<SlotUI> Map(IEnumerable<Slot> listObj)
        {
            List<SlotUI> listSlots = new List<SlotUI>();
            foreach (Slot slot in listObj)
            {
                listSlots.Add(Map(slot));
            }

            return listSlots;
        }

        #endregion

        #region private methods
        /// <summary>
        /// Getting a representation for an assignee
        /// </summary>
        /// <param name="obj">slot used to get the informations</param>
        /// <returns>assignee representation</returns>
        private static string GetAssigneeRepresentation(Slot obj)
        {
            string result = "";
            if (obj != null && obj.Assignee != null)
            {
                result = string.Format("{0} ({1})", obj.Assignee.Name, obj.Assignee.TimeZone.DisplayName);
            }
            return result;
        }

        
        
        #endregion
    }
}
