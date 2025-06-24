using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class EmployeeWorkloadControllerTests
    {
        [Fact]
        public void CanInstantiate_EmployeeWorkloadDto()
        {
            var dto = new EmployeeWorkloadDto();
            Assert.NotNull(dto);
        }

    }
}
