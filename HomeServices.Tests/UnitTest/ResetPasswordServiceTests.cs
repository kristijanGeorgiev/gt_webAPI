using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class ResetPasswordServiceTests
    {

        [Fact]
        public void CanCreateAndAssign_ResetPasswordRequestDto()
        {
            var dto = new ResetPasswordRequestDto();
            Assert.NotNull(dto);
        }

    }
}
