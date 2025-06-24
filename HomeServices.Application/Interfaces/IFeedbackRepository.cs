using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;
using System.Linq.Expressions;

public interface IFeedbackRepository
{
    Task<IEnumerable<FeedbackDto>> GetAllAsync();
    Task<IEnumerable<Feedback>> GetAllEntitiesAsync();
    Task<IEnumerable<Feedback>> GetAllWithBookingAsync();
    Task<Feedback> GetByIdAsync(int id);
    Task<Feedback?> GetByBookingIdAsync(int bookingId);
    Task AddAsync(Feedback entity);
    Task UpdateAsync(Feedback entity);
    Task DeleteAsync(int id);
}

