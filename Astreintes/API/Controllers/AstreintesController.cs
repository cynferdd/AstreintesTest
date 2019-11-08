using DAL;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AstreintesController : Controller
    {
        #region ctor and local variables
        private readonly ISlotService slotService;
        private readonly ISlotRepository slotRepository;
        private readonly IValidation<Slot> slotValidation;
        private readonly IValidation<User> userValidation;
        private readonly EFContext context;

        public AstreintesController(ISlotService service, ISlotRepository repository, IValidation<Slot> slotValidation, IValidation<User> userValidation, EFContext efContext)
        {
            slotService = service;
            slotRepository = repository;
            this.slotValidation = slotValidation;
            this.userValidation = userValidation;
            context = efContext;
        }
        #endregion

        /// <summary>
        /// retrieving all slots, or filtering them with a period
        /// </summary>
        /// <param name="begin">Begin date</param>
        /// <param name="end">End date</param>
        /// <returns>list of duty slots</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]DateTime? begin, [FromQuery]DateTime? end)
        {
            IEnumerable<Slot> slots;
            if (begin.HasValue || end.HasValue)
            {
                slots = await slotService.GetByPeriod(begin == null ? DateTime.MinValue : begin.Value,end == null ? DateTime.MaxValue : end.Value).ConfigureAwait(false);
            }
            else
            {
                slots = await slotService.GetAll().ConfigureAwait(false);
            }
            
            if (slots == null || !slots.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(slots);
            }

        }

        /// <summary>
        /// Get duty slots by assignee id
        /// </summary>
        /// <param name="id">assignee id</param>
        /// <param name="begin">filtering begin date</param>
        /// <param name="end">filtering end date</param>
        /// <returns>list of slots</returns>
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id, [FromQuery]DateTime? begin, [FromQuery]DateTime? end)
        {
            IEnumerable<Slot> slots;
            if (begin.HasValue || end.HasValue)
            {
                slots = await slotService.GetByAssigneeIdAndPeriod(id, begin == null ? DateTime.MinValue : begin.Value, end == null ? DateTime.MaxValue : end.Value).ConfigureAwait(false);
            }
            else
            {
                slots = await slotService.GetByAssigneeId(id).ConfigureAwait(false);
            }

            if (slots == null || !slots.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(slots);
            }

        }
    }
}
