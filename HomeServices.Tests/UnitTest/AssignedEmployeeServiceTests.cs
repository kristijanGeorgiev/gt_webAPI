using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class AssignedEmployeeServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_AssignedEmployeeDto()
        {
            var dto = new AssignedEmployeeDto();
            Assert.NotNull(dto);
        }

    }
}
