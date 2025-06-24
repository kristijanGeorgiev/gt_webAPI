using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class MonthlyBookingControllerTests
    {
        [Fact]
        public void CanInstantiate_MonthlyBookingDto()
        {
            var dto = new MonthlyBookingDto();
            Assert.NotNull(dto);
        }

    }
}
