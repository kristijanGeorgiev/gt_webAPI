using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class EmployeeHoursWorkedServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_EmployeeHoursWorkedDto()
        {
            var dto = new EmployeeHoursWorkedDto();
            Assert.NotNull(dto);
        }

    }
}
