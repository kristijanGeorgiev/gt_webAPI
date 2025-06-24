using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class BookingStatusService : IBookingStatusService
{
    private readonly IBookingStatusRepository _repo;
    private readonly IMapper _mapper;

    public BookingStatusService(IBookingStatusRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookingStatusDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<BookingStatusDto>>(await _repo.GetAllAsync());

    public async Task<BookingStatusDto> GetByIdAsync(int id) =>
        _mapper.Map<BookingStatusDto>(await _repo.GetByIdAsync(id));

    public async Task CreateAsync(BookingStatusDto dto) =>
        await _repo.AddAsync(_mapper.Map<BookingStatus>(dto));

    public async Task UpdateAsync(BookingStatusDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<BookingStatus>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
