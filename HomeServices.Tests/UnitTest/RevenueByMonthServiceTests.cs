using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class RevenueByMonthServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_RevenueByMonthDto()
        {
            var dto = new RevenueByMonthDto();
            Assert.NotNull(dto);
        }

    }
}
