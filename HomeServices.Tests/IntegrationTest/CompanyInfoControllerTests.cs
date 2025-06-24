using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class CompanyInfoControllerTests
    {
        [Fact]
        public void CanInstantiate_CompanyInfoDto()
        {
            var dto = new CompanyInfoDto();
            Assert.NotNull(dto);
        }

    }
}
