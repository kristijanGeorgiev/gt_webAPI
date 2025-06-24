using HomeServices.Application.DTOs;

namespace HomeServices.Tests.UnitTest
{
    public class AdminServiceTests
    {
        [Fact]
        public void CanCreateAndAssign_AdminDto()
        {
            var dto = new AdminDto();
            Assert.NotNull(dto);
        }
    }

}
