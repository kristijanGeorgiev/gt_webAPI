using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class CompanyInfoServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_CompanyInfoDto()
        {
            var dto = new CompanyInfoDto();
            Assert.NotNull(dto);
        }

    }
}
