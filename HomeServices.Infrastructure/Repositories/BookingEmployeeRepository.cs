using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BookingEmployeeRepository : IBookingEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public BookingEmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookingEmployee>> GetAllAsync() =>
        await _context.BookingEmployees.ToListAsync();

    public async Task AddAsync(BookingEmployee entity)
    {
        await _context.BookingEmployees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveAsync(int bookingId, int employeeId)
    {
        var assignment = await _context.BookingEmployees
            .FirstOrDefaultAsync(be => be.BookingId == bookingId && be.EmployeeId == employeeId);

        if (assignment == null) return false;

        _context.BookingEmployees.Remove(assignment);
        await _context.SaveChangesAsync();
        return true;
    }
}

