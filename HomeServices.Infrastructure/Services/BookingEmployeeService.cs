using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class BookingEmployeeService : IBookingEmployeeService
{
    private readonly IBookingEmployeeRepository _repo;
    private readonly IMapper _mapper;

    public BookingEmployeeService(IBookingEmployeeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task AssignEmployeeAsync(BookingEmployeeDto dto) =>
        await _repo.AddAsync(_mapper.Map<BookingEmployee>(dto));

    public async Task RemoveAssignmentAsync(int bookingId, int employeeId) =>
        await _repo.RemoveAsync(bookingId, employeeId);

    public async Task<IEnumerable<BookingEmployeeDto>> GetAssignmentsAsync() =>
        _mapper.Map<IEnumerable<BookingEmployeeDto>>(await _repo.GetAllAsync());
}