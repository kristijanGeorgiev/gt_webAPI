using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class FeedbackControllerTests
    {
        [Fact]
        public void CanInstantiate_FeedbackDto()
        {
            var dto = new FeedbackDto();
            Assert.NotNull(dto);
        }

    }
}
