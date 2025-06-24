using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class AdminDashboardServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_AdminDashboardDto()
        {
            var dto = new AdminDashboardDto();
            Assert.NotNull(dto);
        }
    }

}
