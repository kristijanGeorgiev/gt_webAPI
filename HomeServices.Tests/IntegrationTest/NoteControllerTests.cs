using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.IntegrationTest
{
    public class NoteControllerTests
    {
        [Fact]
        public void CanInstantiate_NoteDto()
        {
            var dto = new NoteDto();
            Assert.NotNull(dto);
        }

    }
}
