
using HomeServices.Domain.Entities;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAllAsync();
    Task<Notification> GetByIdAsync(int id);
    Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, DateTime? fromDate, DateTime? toDate);
    Task AddAsync(Notification notification);
    Task UpdateAsync(Notification notification);
    Task DeleteAsync(int id);
}