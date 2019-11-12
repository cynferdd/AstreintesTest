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
        private readonly IMapper<Slot, SlotUI> mapper;

        public AstreintesController(ISlotService service, ISlotRepository repository, IValidation<Slot> slotValidation, IValidation<User> userValidation, EFContext efContext, IMapper<Slot, SlotUI> slotMapper)
        {
            slotService = service;
            slotRepository = repository;
            this.slotValidation = slotValidation;
            this.userValidation = userValidation;
            context = efContext;
            mapper = slotMapper;
        }
        #endregion

        #region get
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
                slots = await slotService.GetByPeriod(
                    begin == null ? DateTime.MinValue : begin.Value,
                    end == null ? DateTime.MaxValue : end.Value
                ).ConfigureAwait(false);
            }
            else
            {
                slots = await slotService.GetAll().ConfigureAwait(false);
            }

            return ProcessResult(slots);

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
                slots = await slotService.GetByAssigneeIdAndPeriod(
                    id, 
                    begin == null ? DateTime.MinValue : begin.Value, 
                    end == null ? DateTime.MaxValue : end.Value
                ).ConfigureAwait(false);
            }
            else
            {
                slots = await slotService.GetByAssigneeId(id).ConfigureAwait(false);
            }

            return ProcessResult(slots);
            

        }

        /// <summary>
        /// Managing the return result for a Get Request
        /// </summary>
        /// <param name="slots">list of slots to show</param>
        /// <returns>Action result</returns>
        private IActionResult ProcessResult(IEnumerable<Slot> slots)
        {
            if (slots == null || !slots.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map(slots));
            }
        }
        #endregion

        #region POST
        /// <summary>
        /// POST
        /// creating a duty slot
        /// </summary>
        /// <param name="slot">slot to create</param>
        /// <returns>created slot</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SlotUI slot)
        {
            Slot resultat = await slotService.Create(mapper.Map(slot)).ConfigureAwait(false);
            return Ok(mapper.Map(resultat));
            
        }
        #endregion

        /// <summary>
        /// Deleting a slot
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] SlotUI slot)
        {
            bool resultat = await slotService.Delete(mapper.Map(slot)).ConfigureAwait(false);
            return Ok(resultat);
        }

    }
}
