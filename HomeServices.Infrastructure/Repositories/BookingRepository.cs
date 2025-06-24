using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public BookingRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var bookings = await _context.Bookings
            .Include(b => b.Service)
            .Include(b => b.BookingStatus)
            .Include(b => b.AssignedEmployees)
                .ThenInclude(be => be.Employee)
            .ToListAsync();

        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.Service)
            .Include(b => b.BookingStatus)
            .Include(b => b.AssignedEmployees)
                .ThenInclude(be => be.Employee)
            .FirstOrDefaultAsync(b => b.BookingID == id);
    }

    public async Task<IEnumerable<Booking>> GetByAssignedEmployeeAsync(int employeeId, string? status)
    {
        var query = _context.Bookings
            .Include(b => b.BookingStatus)
            .Include(b => b.AssignedEmployees)
            .Where(b => b.AssignedEmployees.Any(a => a.EmployeeId == employeeId));

        if (!string.IsNullOrEmpty(status))
            query = query.Where(b => b.BookingStatus.StatusName == status);

        return await query.ToListAsync();
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        var existing = await _context.Bookings.FindAsync(booking.BookingID);
        if (existing == null) return;

        _context.Entry(existing).CurrentValues.SetValues(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Bookings.FindAsync(id);
        if (entity != null)
        {
            _context.Bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
