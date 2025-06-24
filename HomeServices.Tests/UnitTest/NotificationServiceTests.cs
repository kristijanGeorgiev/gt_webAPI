using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;

namespace HomeServices.Tests.UnitTest
{
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationRepository> _notificationRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _service = new NotificationService(
                _notificationRepoMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetAllNotifications_ShouldReturnNotificationList()
        {

            var fakeNotifications = new List<Notification>();
            var fakeDtos = new List<NotificationDto>();

            _notificationRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(fakeNotifications);
            _mapperMock.Setup(m => m.Map<IEnumerable<NotificationDto>>(fakeNotifications)).Returns(fakeDtos);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<NotificationDto>>(result);
        }
    }
}
