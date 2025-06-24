using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class CreateUserServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_CreateUserDto()
        {
            var dto = new CreateUserDto();
            Assert.NotNull(dto);
        }

    }
}
