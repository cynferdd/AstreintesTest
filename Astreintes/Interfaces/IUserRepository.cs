using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Getting a specific user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>corresponding user</returns>
        Task<User> Get(int id);
    }
}
