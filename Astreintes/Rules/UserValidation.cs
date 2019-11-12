using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules
{
    public class UserValidation : IValidation<User>
    {
        /// <summary>
        /// is the user valid ?
        /// </summary>
        /// <param name="user">user to check</param>
        /// <returns>valid user ?</returns>
        public bool CheckValidation(User user)
        {
            return user != null && !string.IsNullOrWhiteSpace(user.Name);
        }
    }
}
