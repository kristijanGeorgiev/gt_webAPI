using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;

namespace HomeServices.Tests.UnitTest
{
    public class FeedbackServiceTests
    {
        private readonly Mock<IFeedbackRepository> _repoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<INotificationBuilderService> _notifierMock = new();
        private readonly Mock<IBookingRepository> _bookingRepoMock = new();

        private readonly FeedbackService _service;

        public FeedbackServiceTests()
        {
            _service = new FeedbackService(
                _repoMock.Object,
                _mapperMock.Object,
                _notifierMock.Object,
                _bookingRepoMock.Object
            );
        }

        [Fact]
        public async Task GetAllFeedbacks_ShouldReturnFeedbackList()
        {
            var mockFeedbacks = new List<Feedback>();
            var mockFeedbackDtos = new List<FeedbackDto>();
            _mapperMock.Setup(m => m.Map<IEnumerable<FeedbackDto>>(mockFeedbacks)).Returns(mockFeedbackDtos);
            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<FeedbackDto>>(result);
        }
    }
}


