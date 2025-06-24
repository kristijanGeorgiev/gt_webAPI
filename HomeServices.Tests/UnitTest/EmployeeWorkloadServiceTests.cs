using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class EmployeeWorkloadServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_EmployeeWorkloadDto()
        {
            var dto = new EmployeeWorkloadDto();
            Assert.NotNull(dto);
        }

    }
}
