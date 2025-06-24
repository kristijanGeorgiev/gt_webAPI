using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BookingStatusRepository : IBookingStatusRepository
{
    private readonly ApplicationDbContext _context;

    public BookingStatusRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookingStatus>> GetAllAsync() => await _context.BookingStatus.ToListAsync();
    public async Task<BookingStatus> GetByIdAsync(int id) => await _context.BookingStatus.FindAsync(id);
    public async Task AddAsync(BookingStatus entity) {
        await _context.BookingStatus.AddAsync(entity);
        await _context.SaveChangesAsync();
}
    public async Task UpdateAsync(BookingStatus entity) {
        _context.BookingStatus.Update(entity);
        await _context.SaveChangesAsync();
     }
    public async Task DeleteAsync(int id)
    {
        var entity = await _context.BookingStatus.FindAsync(id);
        if (entity != null) _context.BookingStatus.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
