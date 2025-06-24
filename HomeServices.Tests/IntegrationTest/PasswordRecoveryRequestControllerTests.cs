using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class PasswordRecoveryRequestControllerTests
    {
        [Fact]
        public void CanInstantiate_PasswordRecoveryRequestDto()
        {
            var dto = new PasswordRecoveryRequestDto();
            Assert.NotNull(dto);
        }

    }
}
