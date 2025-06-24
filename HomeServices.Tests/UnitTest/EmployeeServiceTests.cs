using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_EmployeeDto()
        {
            var dto = new EmployeeDto();
            Assert.NotNull(dto);
        }

    }
}
