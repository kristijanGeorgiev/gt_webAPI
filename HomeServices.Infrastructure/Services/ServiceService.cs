using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repo;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<ServiceDto>>(await _repo.GetAllAsync());

    public async Task<ServiceDto> GetByIdAsync(int id) =>
        _mapper.Map<ServiceDto>(await _repo.GetByIdAsync(id));

    public async Task CreateAsync(ServiceDto dto) =>
        await _repo.AddAsync(_mapper.Map<Service>(dto));

    public async Task UpdateAsync(ServiceDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<Service>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}