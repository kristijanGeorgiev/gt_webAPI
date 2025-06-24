using HomeServices.Application.DTOs;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetAllAsync();
    Task<NotificationDto> GetByIdAsync(int id);
    Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId, DateTime? fromDate, DateTime? toDate);

    Task CreateAsync(NotificationDto dto);
    Task UpdateAsync(NotificationDto dto);
    Task DeleteAsync(int id);
}
