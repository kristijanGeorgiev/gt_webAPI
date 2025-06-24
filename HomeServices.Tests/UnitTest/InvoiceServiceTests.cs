using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class InvoiceServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_InvoiceDto()
        {
            var dto = new InvoiceDto();
            Assert.NotNull(dto);
        }

    }
}
