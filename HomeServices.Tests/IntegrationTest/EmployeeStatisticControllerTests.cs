using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class EmployeeStatisticControllerTests
    {

        [Fact]
        public void CanInstantiate_EmployeeStatisticDto()
        {
            var dto = new EmployeeStatisticDto();
            Assert.NotNull(dto);
        }

    }
}
