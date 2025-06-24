using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class ClientControllerTests
    {
        [Fact]
        public void CanInstantiate_ClientDto()
        {
            var dto = new ClientDto();
            Assert.NotNull(dto);
        }

    }
}
