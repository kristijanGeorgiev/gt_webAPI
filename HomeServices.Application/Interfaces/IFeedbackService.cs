using HomeServices.Application.DTOs;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDto>> GetAllAsync(int? serviceId = null, DateTime? fromDate = null, DateTime? toDate = null);
    Task<FeedbackDto> GetByIdAsync(int id);
    Task<FeedbackDto?> GetFeedbackByBookingIdAsync(int bookingId);
    Task CreateAsync(FeedbackDto dto);
    Task UpdateAsync(FeedbackDto dto);
    Task DeleteAsync(int id);
}
