using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class AdminStatisticControllerTests
    {
        [Fact]
        public void CanInstantiate_AdminStatisticDto()
        {
            var dto = new AdminStatisticDto();
            Assert.NotNull(dto);
        }

    }
}
