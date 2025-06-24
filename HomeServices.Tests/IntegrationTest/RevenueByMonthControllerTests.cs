using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class RevenueByMonthControllerTests
    {
        [Fact]
        public void CanInstantiate_RevenueByMonthDto()
        {
            var dto = new RevenueByMonthDto();
            Assert.NotNull(dto);
        }

    }
}
