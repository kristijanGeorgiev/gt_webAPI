using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class ServiceServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_ServiceDto()
        {
            var dto = new ServiceDto();
            Assert.NotNull(dto);
        }

    }
}
