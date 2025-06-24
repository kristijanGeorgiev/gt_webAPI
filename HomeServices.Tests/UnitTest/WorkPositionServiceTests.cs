using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Moq;

public class WorkPositionServiceTests
{
    private readonly Mock<IWorkPositionRepository> _repoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly WorkPositionService _service;

    public WorkPositionServiceTests()
    {
        _service = new WorkPositionService(_repoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnWorkPositions()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<WorkPosition>());
        _mapperMock.Setup(m => m.Map<IEnumerable<WorkPositionDto>>(It.IsAny<IEnumerable<WorkPosition>>())).Returns(new List<WorkPositionDto>());

        var result = await _service.GetAllAsync();

        Assert.NotNull(result);
    }
}
