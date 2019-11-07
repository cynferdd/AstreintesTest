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
        [Fact]
        public void UserNullReturnsKO()
        {

            bool result = new UserValidation().CheckValidation(null);
            Assert.False(result);
        }

        [Fact]
        public void UserNoNameReturnsKO()
        {

            bool result = new UserValidation().CheckValidation(new User());
            Assert.False(result);
        }


        [Fact]
        public void UserValidReturnsKO()
        {

            bool result = new UserValidation().CheckValidation(new User() { Name = "Max Lamouche" });
            Assert.True(result);
        }
    }
}
