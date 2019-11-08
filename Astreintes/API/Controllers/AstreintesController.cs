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

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            IEnumerable<Slot> slots = await slotService.GetAll().ConfigureAwait(false);
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
