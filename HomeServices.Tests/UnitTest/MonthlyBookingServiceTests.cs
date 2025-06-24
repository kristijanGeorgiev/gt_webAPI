using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class MonthlyBookingServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_MonthlyBookingDto()
        {
            var dto = new MonthlyBookingDto();
            Assert.NotNull(dto);
        }

    }
}
