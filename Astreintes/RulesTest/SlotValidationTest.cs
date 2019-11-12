using Entities;
using Interfaces;
using Moq;
using Rules;
using System;
using Xunit;

namespace RulesTest
{
    public class SlotValidationTest
    {
        #region Dates
        /// <summary>
        /// Check date validity with a begin date starting before the end date
        /// </summary>
        [Fact]
        public void SlotBeginDateBeforeEndDateReturnsOk()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation(GetUserValidation(true)).CheckDateValidity(slot);
            Assert.True(result);
        }

        /// <summary>
        /// Check date validity with a begin date equal to the end date
        /// </summary>
        [Fact]
        public void SlotBeginDateEqualEndDateReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17, 2,17,33),
                EndDate = new DateTime(1982, 05, 17, 2, 17, 33)
            };
            bool result = new SlotValidation(GetUserValidation(true)).CheckDateValidity(slot);
            Assert.False(result);
        }

        /// <summary>
        /// Check date validity with a begin date starting after the end date
        /// </summary>
        [Fact]
        public void SlotBeginDateAfterEndDateReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1993, 02, 1, 5, 23, 6),
                EndDate = new DateTime(1982, 05, 17, 2, 17, 33)
            };
            bool result = new SlotValidation(GetUserValidation(true)).CheckDateValidity(slot);
            Assert.False(result);
        }

        /// <summary>
        /// Check date validity with a null slot
        /// </summary>
        [Fact]
        public void DateSlotNullReturnsKO()
        {
            
            bool result = new SlotValidation(GetUserValidation(true)).CheckDateValidity(null);
            Assert.False(result);
        }

        /// <summary>
        /// Check date validity with an empty slot
        /// </summary>
        [Fact]
        public void DateSlotEmptyReturnsKO()
        {

            bool result = new SlotValidation(GetUserValidation(true)).CheckDateValidity(new Slot());
            Assert.False(result);
        }
        #endregion

        #region slot

        /// <summary>
        /// Check slot validation with a null slot
        /// </summary>
        [Fact]
        public void SlotNullReturnsKO()
        {
            
            bool result = new SlotValidation(GetUserValidation(true)).CheckValidation(null);
            Assert.False(result);
        }

        /// <summary>
        /// Check slot validation with a not valid assignee 
        /// </summary>
        [Fact]
        public void SlotAssigneeNotValidReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation(GetUserValidation(false)).CheckValidation(slot);
            Assert.False(result);
        }

        /// <summary>
        /// Check slot validation with a valid assignee and not valid dates
        /// </summary>
        [Fact]
        public void SlotAssigneeokDatesKoReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = new User(),
                BeginDate = new DateTime(1982, 09, 17),
                EndDate = new DateTime(1980, 07, 22)
            };
            bool result = new SlotValidation(GetUserValidation(true)).CheckValidation(slot);
            Assert.False(result);
        }

        /// <summary>
        /// Check slot validation with a valid assignee and valid dates
        /// </summary>
        [Fact]
        public void SlotAssigneeokDatesOkReturnsOk()
        {
            Slot slot = new Slot()
            {
                Assignee = new User(),
                BeginDate = new DateTime(1982, 01, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation(GetUserValidation(true)).CheckValidation(slot);
            Assert.True(result);
        }
        #endregion

        #region Mock
        private IValidation<User> GetUserValidation(bool isValid)
        {
            var mockUserValidation = new Mock<IValidation<User>>();
            mockUserValidation.Setup(m => m.CheckValidation(It.IsAny<User>())).Returns(isValid);
            return mockUserValidation.Object;
        }
        #endregion
    }
}
