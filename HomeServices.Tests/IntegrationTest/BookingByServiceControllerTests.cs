using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class BookingByServiceControllerTests
    {
        [Fact]
        public void CanInstantiate_BookingsByServiceDto()
        {
            var dto = new BookingsByServiceDto();
            Assert.NotNull(dto);
        }

    }
}
