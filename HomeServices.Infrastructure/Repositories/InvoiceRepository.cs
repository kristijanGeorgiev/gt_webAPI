using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationDbContext _context;

    public InvoiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync(bool? isPaid, DateTime? fromDate, DateTime? toDate, int? userId)
    {
        var query = _context.Invoices
            .Include(i => i.Booking)
                .ThenInclude(b => b.Service)
            .AsQueryable();

        if (isPaid.HasValue)
        {
            query = query.Where(i => i.IsPaid == isPaid.Value);
        }

        if (fromDate.HasValue)
        {
            query = query.Where(i => i.IssuedDate.Date >= fromDate.Value.Date);
        }

        if (toDate.HasValue)
        {
            query = query.Where(i => i.IssuedDate.Date <= toDate.Value.Date);
        }
        if (userId.HasValue)
        {
            query = query.Where(i => i.Booking.UserID == userId.Value);
        }

        return await query.ToListAsync();
    }
    public async Task<Invoice> GetByIdAsync(int id)
    {
        return await _context.Invoices.Include(i => i.Booking).ThenInclude(b => b.Service).FirstOrDefaultAsync(i => i.InvoiceID == id);
    }

    public async Task<Invoice?> GetByBookingIdAsync(int bookingId) =>
        await _context.Invoices.Include(i => i.Booking).ThenInclude(b => b.Service).FirstOrDefaultAsync(i => i.BookingID == bookingId);

    public async Task AddAsync(Invoice entity)
    {
        await _context.Invoices.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Invoice entity)
    {
        _context.Invoices.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Invoices.FindAsync(id);
        if (entity != null)
        {
            _context.Invoices.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
