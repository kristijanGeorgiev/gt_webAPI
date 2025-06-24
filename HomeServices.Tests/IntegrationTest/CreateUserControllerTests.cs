using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class CreateUserControllerTests
    {
        [Fact]
        public void CanInstantiate_CreateUserDto()
        {
            var dto = new CreateUserDto();
            Assert.NotNull(dto);
        }

    }
}
