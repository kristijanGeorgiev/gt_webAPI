using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class UpdateUserControllerTests
    {
        [Fact]
        public void CanInstantiate_UpdateUserDto()
        {
            var dto = new UpdateUserDto();
            Assert.NotNull(dto);
        }

    }
}
