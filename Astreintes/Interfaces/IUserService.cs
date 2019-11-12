using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Getting all users
        /// </summary>
        /// <returns>list of users</returns>
        Task<IEnumerable<User>> GetAll();

        /// <summary>
        /// Getting one user
        /// </summary>
        /// <param name="Id">User id</param>
        /// <returns>corresponding user</returns>
        Task<User> Get(int Id);

        /// <summary>
        /// Creating a user
        /// </summary>
        /// <param name="user">user to create</param>
        /// <returns>Created user</returns>
        Task<User> Create(User user);
    }
}
