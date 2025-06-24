using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;
using Xunit;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _repoMock = new();
    private readonly Mock<IBookingRepository> _bookingRepoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<INotificationBuilderService> _notificationBuilderMock = new();

    private readonly UserService _service;

    public UserServiceTests()
    {
        _service = new UserService(
            _repoMock.Object,
            _bookingRepoMock.Object,
            _mapperMock.Object,
            _notificationBuilderMock.Object
        );
    }

    [Fact]
    public async Task GetAllClientsAsync_ShouldReturnMappedClients()
    {
        var users = new List<User>
        {
            new User { UserId = 1, Role = "Client" },
            new User { UserId = 2, Role = "Employee" },
            new User { UserId = 3, Role = "Client" }
        };

        var expectedClients = users.Where(u => u.Role == "Client").ToList();
        var clientDtos = new List<ClientDto>
        {
            new ClientDto { UserId = 1 },
            new ClientDto { UserId = 3 }
        };

        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);
        _mapperMock.Setup(m => m.Map<IEnumerable<ClientDto>>(It.Is<IEnumerable<User>>(u => u.All(x => x.Role == "Client"))))
                   .Returns(clientDtos);

        var result = await _service.GetAllClientsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, r => r.UserId == 1);
        Assert.Contains(result, r => r.UserId == 3);
    }
}