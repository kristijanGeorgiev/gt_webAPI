using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class AdminDashboardControllerTests
    {
        [Fact]
        public void CanInstantiate_AdminDashboardDto()
        {
            var dto = new AdminDashboardDto();
            Assert.NotNull(dto);
        }

    }
}
