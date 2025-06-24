using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repo;
    private readonly IMapper _mapper;

    public NotificationService(INotificationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<NotificationDto>>(await _repo.GetAllAsync());

    public async Task<NotificationDto> GetByIdAsync(int id) =>
        _mapper.Map<NotificationDto>(await _repo.GetByIdAsync(id));
    public async Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId, DateTime? fromDate, DateTime? toDate)
    {
        var notifications = await _repo.GetByUserIdAsync(userId, fromDate, toDate);
        return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
    }


    public async Task CreateAsync(NotificationDto dto) =>
        await _repo.AddAsync(_mapper.Map<Notification>(dto));

    public async Task UpdateAsync(NotificationDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<Notification>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}