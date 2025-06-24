using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class EmployeeStatisticServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_EmployeeStatisticDto()
        {
            var dto = new EmployeeStatisticDto();
            Assert.NotNull(dto);
        }
    }
}
