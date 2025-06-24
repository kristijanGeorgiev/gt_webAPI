using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _context;

    public NotificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notification>> GetAllAsync() =>
        await _context.Notifications.ToListAsync();

    public async Task<Notification> GetByIdAsync(int id) =>
        await _context.Notifications.FindAsync(id);
    public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Notifications.AsQueryable();

        query = query.Where(n => n.UserID == userId);

        if (fromDate.HasValue)
            query = query.Where(n => n.CreatedAt.Date >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(n => n.CreatedAt.Date <= toDate.Value);

        return await query.OrderByDescending(n => n.CreatedAt).ToListAsync();
    }


    public async Task AddAsync(Notification entity)
    {
        await _context.Notifications.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Notification entity)
    {
        _context.Notifications.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Notifications.FindAsync(id);
        if (entity != null)
        {
            _context.Notifications.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
