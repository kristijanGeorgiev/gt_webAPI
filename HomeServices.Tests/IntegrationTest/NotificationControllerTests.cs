using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class NotificationControllerTests
    {
        [Fact]
        public void CanInstantiate_NotificationDto()
        {
            var dto = new NotificationDto();
            Assert.NotNull(dto);
        }

    }
}
