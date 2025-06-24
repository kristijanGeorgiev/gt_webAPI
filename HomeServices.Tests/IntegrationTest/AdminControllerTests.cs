using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class AdminControllerTests
    {

        [Fact]
        public void CanInstantiate_AdminDto()
        {
            var dto = new AdminDto();
            Assert.NotNull(dto);
        }

    }
}
