using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class EmployeeHoursWorkedControllerTests
    {
        [Fact]
        public void CanInstantiate_EmployeeHoursWorkedDto()
        {
            var dto = new EmployeeHoursWorkedDto();
            Assert.NotNull(dto);
        }

    }
}
