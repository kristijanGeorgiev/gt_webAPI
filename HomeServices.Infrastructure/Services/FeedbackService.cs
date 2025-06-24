using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _repo;
    private readonly IMapper _mapper;
    private readonly INotificationBuilderService _notificationBuilder;
    private readonly IBookingRepository _bookingRepo;

    public FeedbackService(IFeedbackRepository repo, IMapper mapper, INotificationBuilderService notificationBuilder, IBookingRepository bookingRepo)
    {
        _repo = repo;
        _mapper = mapper;
        _notificationBuilder = notificationBuilder;
        _bookingRepo = bookingRepo;
    }

    public async Task<IEnumerable<FeedbackDto>> GetAllAsync(int? serviceId = null, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var feedbacks = await _repo.GetAllAsync();
        var filtered = feedbacks.AsQueryable();

        if (serviceId.HasValue)
            filtered = filtered.Where(b => b.ServiceID == serviceId.Value);

        if (fromDate.HasValue)
            filtered = filtered.Where(b => b.ServiceDate.Date >= fromDate.Value.Date);

        if (toDate.HasValue)
            filtered = filtered.Where(b => b.ServiceDate.Date <= toDate.Value.Date);

        return filtered.ToList();

}


    public async Task<FeedbackDto> GetByIdAsync(int id) =>
        _mapper.Map<FeedbackDto>(await _repo.GetByIdAsync(id));

    public async Task<FeedbackDto?> GetFeedbackByBookingIdAsync(int bookingId)
    {
        var feedback = await _repo.GetByBookingIdAsync(bookingId);
        return _mapper.Map<FeedbackDto?>(feedback);
    }

    public async Task CreateAsync(FeedbackDto dto)
    {
        var feedback = _mapper.Map<Feedback>(dto);
        await _repo.AddAsync(feedback);

        var booking = await _bookingRepo.GetByIdAsync(dto.BookingID);
        if (booking != null)
        {
            var message = $"New feedback received for booking #{booking.BookingID}.";
            await _notificationBuilder.NotifyFeedbackAddedAsync(booking.UserID, message);
        }
    }

    public async Task UpdateAsync(FeedbackDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<Feedback>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
