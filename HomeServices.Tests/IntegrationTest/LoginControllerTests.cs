using HomeServices.Application.DTOs.HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class LoginControllerTests
    {

        [Fact]
        public void CanInstantiate_LoginDto()
        {
            var dto = new LoginDto();
            Assert.NotNull(dto);
        }

    }
}
