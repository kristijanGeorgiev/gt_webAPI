using HomeServices.Application.DTOs.HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class LoginServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_LoginDto()
        {
            var dto = new LoginDto();
            Assert.NotNull(dto);
        }

    }
}
