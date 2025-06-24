using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;

public class BookingEmployeeServiceTests
{
    private readonly Mock<IBookingEmployeeRepository> _repoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly BookingEmployeeService _service;

    public BookingEmployeeServiceTests()
    {
        _service = new BookingEmployeeService(_repoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetAssignmentsAsync_ShouldReturnAssignments()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<BookingEmployee>());
        _mapperMock.Setup(m => m.Map<IEnumerable<BookingEmployeeDto>>(It.IsAny<IEnumerable<BookingEmployee>>())).Returns(new List<BookingEmployeeDto>());

        var result = await _service.GetAssignmentsAsync();

        Assert.NotNull(result);
    }
}
