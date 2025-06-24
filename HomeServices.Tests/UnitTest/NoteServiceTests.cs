using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Tests.UnitTest
{
    public class NoteServiceTests
    {

        [Fact]
        public void CanCreateAndAssign_NoteDto()
        {
            var dto = new NoteDto();
            Assert.NotNull(dto);
        }

    }
}
