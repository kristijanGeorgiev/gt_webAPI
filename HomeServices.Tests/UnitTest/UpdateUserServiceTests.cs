using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class UpdateUserServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_UpdateUserDto()
        {
            var dto = new UpdateUserDto();
            Assert.NotNull(dto);
        }

    }
}
