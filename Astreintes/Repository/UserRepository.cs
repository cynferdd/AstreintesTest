using DAL;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EFContext context;
        public UserRepository(EFContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creating a user
        /// </summary>
        /// <param name="obj">user to create</param>
        /// <returns>created user</returns>
        public async Task<User> Create(User obj)
        {
            var added = await context.Users.AddAsync(obj).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return added.Entity;
        }

        /// <summary>
        /// Deleting a user
        /// </summary>
        /// <param name="obj">user to delete</param>
        /// <returns>Was the deletion done ?</returns>
        public async Task<bool> Delete(User obj)
        {
            var deleted = context.Users.Remove(obj);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return deleted.Entity != null;
        }

        /// <summary>
        /// Getting a specific user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User corresponding to the given id</returns>
        public async Task<User> Get(int id)
        {
            return await context.Users.FindAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Getting all users
        /// </summary>
        /// <returns>list of all users</returns>
        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync().ConfigureAwait(false);
        }
    }
}
