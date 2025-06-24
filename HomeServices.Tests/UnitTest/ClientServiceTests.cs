using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class ClientServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_ClientDto()
        {
            var dto = new ClientDto();
            Assert.NotNull(dto);
        }

    }
}
