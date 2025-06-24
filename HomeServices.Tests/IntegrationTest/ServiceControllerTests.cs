using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class ServiceControllerTests
    {
        [Fact]
        public void CanInstantiate_ServiceDto()
        {
            var dto = new ServiceDto();
            Assert.NotNull(dto);
        }

    }
}
