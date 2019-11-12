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
    public class UsersController : Controller
    {
        private readonly IUserService service;
        private readonly IUserRepository repository;
        private readonly IValidation<User> validation;
        private readonly EFContext context;
        public UsersController(IUserService userService, IUserRepository userRepository, IValidation<User> userValidation, EFContext efContext)
        {
            service = userService;
            repository = userRepository;
            validation = userValidation;
            context = efContext;
        }

        #region get
        /// <summary>
        /// retrieving all users
        /// </summary>
        /// <returns>list of users</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User>  users = await service.GetAll().ConfigureAwait(false);

            if (users == null || !users.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(users);
            }
        }


        /// <summary>
        /// Get a user with his/her id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>list of users</returns>
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await service.Get(id).ConfigureAwait(false);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }


        #endregion

        #region POST
        /// <summary>
        /// POST
        /// creating a user
        /// </summary>
        /// <param name="user">user to create</param>
        /// <returns>created user</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User resultat = await service.Create(user).ConfigureAwait(false);
            return Ok(resultat);

        }
        #endregion
    }
}
