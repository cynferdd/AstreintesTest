using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repo)
        {
            repository = repo;
        }
        /// <summary>
        /// Creating a user
        /// </summary>
        /// <param name="user">User to create</param>
        /// <returns>created user</returns>
        public async Task<User> Create(User user)
        {
            return await repository.Create(user).ConfigureAwait(false);
        }

        public async Task<User> Get(int Id)
        {
            return await repository.Get(Id);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
