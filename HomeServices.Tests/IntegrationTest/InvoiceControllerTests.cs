using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class InvoiceControllerTests
    {
        [Fact]
        public void CanInstantiate_InvoiceDto()
        {
            var dto = new InvoiceDto();
            Assert.NotNull(dto);
        }

    }
}
