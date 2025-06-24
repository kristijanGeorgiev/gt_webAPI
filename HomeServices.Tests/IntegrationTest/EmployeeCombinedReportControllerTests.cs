using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class EmployeeCombinedReportControllerTests
    {
        [Fact]
        public void CanInstantiate_EmployeeCombinedReportDto()
        {
            var dto = new EmployeeCombinedReportDto();
            Assert.NotNull(dto);
        }

    }
}
