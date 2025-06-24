using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class WorkPositionService : IWorkPositionService
{
    private readonly IWorkPositionRepository _repo;
    private readonly IMapper _mapper;

    public WorkPositionService(IWorkPositionRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkPositionDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<WorkPositionDto>>(await _repo.GetAllAsync());

    public async Task<WorkPositionDto> GetByIdAsync(int id) =>
        _mapper.Map<WorkPositionDto>(await _repo.GetByIdAsync(id));

    public async Task CreateAsync(WorkPositionDto dto) =>
        await _repo.AddAsync(_mapper.Map<WorkPosition>(dto));

    public async Task UpdateAsync(WorkPositionDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<WorkPosition>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
