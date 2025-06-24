using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void CanInstantiate_EmployeeDto()
        {
            var dto = new EmployeeDto();
            Assert.NotNull(dto);
        }

    }
}
