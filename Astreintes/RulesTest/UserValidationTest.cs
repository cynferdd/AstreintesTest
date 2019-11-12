using Entities;
using Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RulesTest
{
    public class UserValidationTest
    {
        /// <summary>
        /// User validation with a null user
        /// </summary>
        [Fact]
        public void UserNullReturnsKO()
        {

            bool result = new UserValidation().CheckValidation(null);
            Assert.False(result);
        }

        /// <summary>
        /// User validation with an empty user
        /// </summary>
        [Fact]
        public void UserNoNameReturnsKO()
        {

            bool result = new UserValidation().CheckValidation(new User());
            Assert.False(result);
        }

        /// <summary>
        /// User validation with a valid user
        /// </summary>
        [Fact]
        public void UserValidReturnsOK()
        {

            bool result = new UserValidation().CheckValidation(new User() { Name = "Max Lamouche" });
            Assert.True(result);
        }
    }
}
