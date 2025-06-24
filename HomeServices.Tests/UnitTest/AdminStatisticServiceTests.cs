using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class AdminStatisticServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_AdminStatisticDto()
        {
            var dto = new AdminStatisticDto();
            Assert.NotNull(dto);
        }

    }
}
