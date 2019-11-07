using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules
{
    public class UserValidation : IValidation<User>
    {
        public bool CheckValidation(User user)
        {
            return user != null && !string.IsNullOrWhiteSpace(user.Name);
        }
    }
}
