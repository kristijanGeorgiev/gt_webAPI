using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class AssignedEmployeeControllerTests
    {
        [Fact]
        public void CanInstantiate_AssignedEmployeeDto()
        {
            var dto = new AssignedEmployeeDto();
            Assert.NotNull(dto);
        }

    }
}
