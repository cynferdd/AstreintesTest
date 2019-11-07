using Entities;
using Rules;
using System;
using Xunit;

namespace RulesTest
{
    public class SlotValidationTest
    {
        #region Dates
        [Fact]
        public void SlotBeginDateBeforeEndDateReturnsOk()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation().CheckDateValidity(slot);
            Assert.True(result);
        }

        [Fact]
        public void SlotBeginDateEqualEndDateReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17, 2,17,33),
                EndDate = new DateTime(1982, 05, 17, 2, 17, 33)
            };
            bool result = new SlotValidation().CheckDateValidity(slot);
            Assert.False(result);
        }

        [Fact]
        public void SlotBeginDateAfterEndDateReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1993, 02, 1, 5, 23, 6),
                EndDate = new DateTime(1982, 05, 17, 2, 17, 33)
            };
            bool result = new SlotValidation().CheckDateValidity(slot);
            Assert.False(result);
        }

        [Fact]
        public void DateSlotNullReturnsKO()
        {
            
            bool result = new SlotValidation().CheckDateValidity(null);
            Assert.False(result);
        }

        [Fact]
        public void DateSlotEmptyReturnsKO()
        {

            bool result = new SlotValidation().CheckDateValidity(new Slot());
            Assert.False(result);
        }
        #endregion

        #region slot

        [Fact]
        public void SlotNullReturnsKO()
        {

            bool result = new SlotValidation().CheckValidation(null);
            Assert.False(result);
        }

        [Fact]
        public void SlotAssigneeNullReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = null,
                BeginDate = new DateTime(1982, 05, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation().CheckValidation(slot);
            Assert.False(result);
        }

        [Fact]
        public void SlotAssigneeokDatesKoReturnsKO()
        {
            Slot slot = new Slot()
            {
                Assignee = new User(),
                BeginDate = new DateTime(1982, 09, 17),
                EndDate = new DateTime(1980, 07, 22)
            };
            bool result = new SlotValidation().CheckValidation(slot);
            Assert.False(result);
        }

        [Fact]
        public void SlotAssigneeokDatesOkReturnsOk()
        {
            Slot slot = new Slot()
            {
                Assignee = new User(),
                BeginDate = new DateTime(1982, 01, 17),
                EndDate = new DateTime(1985, 07, 22)
            };
            bool result = new SlotValidation().CheckValidation(slot);
            Assert.True(result);
        }
        #endregion
    }
}
