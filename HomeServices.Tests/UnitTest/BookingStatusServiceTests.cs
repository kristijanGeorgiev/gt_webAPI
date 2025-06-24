using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;

public class BookingStatusServiceTests
{
    private readonly Mock<IBookingStatusRepository> _repoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly BookingStatusService _service;

    public BookingStatusServiceTests()
    {
        _service = new BookingStatusService(_repoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBookingStatuses()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<BookingStatus>());
        _mapperMock.Setup(m => m.Map<IEnumerable<BookingStatusDto>>(It.IsAny<IEnumerable<BookingStatus>>())).Returns(new List<BookingStatusDto>());

        var result = await _service.GetAllAsync();

        Assert.NotNull(result);
    }
}
