using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class EmployeeCombinedReportServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_EmployeeCombinedReportDto()
        {
            var dto = new EmployeeCombinedReportDto();
            Assert.NotNull(dto);
        }

    }
}
