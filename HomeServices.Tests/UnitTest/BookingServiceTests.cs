using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;
using Xunit;

public class BookingServiceTests
{
    private readonly Mock<IBookingRepository> _repoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<INotificationBuilderService> _notificationBuilderMock = new();
    private readonly Mock<IBookingEmployeeRepository> _bookingEmployeeRepoMock = new();

    private readonly BookingService _service;

    public BookingServiceTests()
    {
        _service = new BookingService(
            _repoMock.Object,
            _mapperMock.Object,
            _notificationBuilderMock.Object,
            _bookingEmployeeRepoMock.Object
        );
    }

    [Fact]
    public async Task GetAllBookingsAsync_ShouldReturnMappedResult()
    {
        var bookings = new List<Booking> { new Booking { BookingID = 1, UserID = 2, ServiceID = 1, BookingDate = DateTime.Now, BookingStatusId = 1, ServiceDate = DateTime.Now, ContactName = "", Address = "", Price = 0, Description = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsPaid = true, PaymentMethod = "", AdministratorID = null } };
        var bookingDtos = new List<BookingDto> { new BookingDto { BookingID = 1, UserID = 2, ServiceID = 1, BookingDate = DateTime.Now, BookingStatusId = 1, ServiceDate = DateTime.Now, ContactName = "", Address = "", Price = 0, Description = "", IsPaid = true, PaymentMethod = "" } };

        _mapperMock.Setup(m => m.Map<IEnumerable<BookingDto>>(bookings)).Returns(bookingDtos);

        var result = await _service.GetAllBookingsAsync(null, null, null, null);
    }
}
