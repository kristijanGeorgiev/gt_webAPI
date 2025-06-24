using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class PasswordRecoveryRequestServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_PasswordRecoveryRequestDto()
        {
            var dto = new PasswordRecoveryRequestDto();
            Assert.NotNull(dto);
        }

    }
}
