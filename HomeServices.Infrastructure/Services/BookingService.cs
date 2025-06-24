using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _repo;
    private readonly INotificationBuilderService _notificationBuilder;
    private readonly IBookingEmployeeRepository _bookingEmployeeRepo;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository repo, IMapper mapper, INotificationBuilderService notificationBuilder, IBookingEmployeeRepository bookingEmployeeRepository)
    {
        _repo = repo;
        _mapper = mapper;
        _notificationBuilder = notificationBuilder;
        _bookingEmployeeRepo = bookingEmployeeRepository;
  
    }

    public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync(int? statusId, bool? isPaid, DateTime? fromDate, DateTime? toDate)
    {
        var bookings = await _repo.GetAllAsync();

        var filtered = bookings.AsQueryable();

        if (statusId.HasValue)
            filtered = filtered.Where(b => b.BookingStatusId == statusId.Value);

        if (isPaid.HasValue)
            filtered = filtered.Where(b => b.IsPaid == isPaid.Value);

        if (fromDate.HasValue)
            filtered = filtered.Where(b => b.BookingDate.Date >= fromDate.Value.Date);

        if (toDate.HasValue)
            filtered = filtered.Where(b => b.BookingDate.Date <= toDate.Value.Date);

        return filtered.ToList();
    }

    public async Task<BookingDto> GetBookingByIdAsync(int id) =>
        _mapper.Map<BookingDto>(await _repo.GetByIdAsync(id));
    public async Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(int userId, DateTime? fromDate = null, DateTime? toDate = null, int? statusId = null)
    {
        var bookings = await _repo.GetAllAsync();

        var filtered = bookings.Where(b => b.UserID == userId);

        if (fromDate.HasValue)
        {
            filtered = filtered.Where(b => b.BookingDate.Date >= fromDate.Value.Date);
        }

        if (toDate.HasValue)
        {
            filtered = filtered.Where(b => b.BookingDate.Date <= toDate.Value.Date);
        }

        if (statusId.HasValue)
        {
            filtered = filtered.Where(b => b.BookingStatusId == statusId.Value);
        }

        return _mapper.Map<IEnumerable<BookingDto>>(filtered);
    }

    public async Task<IEnumerable<BookingDto>> GetBookingsByAssignedEmployeeAsync(int employeeId, string? status = null)
    {
        var bookings = await _repo.GetAllAsync();

        var filtered = bookings
            .Where(b => b.AssignedEmployees.Any(ae => ae.EmployeeId == employeeId));

        if (!string.IsNullOrEmpty(status))
        {
            filtered = filtered.Where(b => b.BookingStatusName == status);

        }

        return _mapper.Map<IEnumerable<BookingDto>>(filtered);
    }


    public async Task<IEnumerable<BookingDto>> GetBookingsByStatusIdAsync(int statusId)
    {
        var bookings = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<BookingDto>>(bookings.Where(b => b.BookingStatusId == statusId));
    }
    public async Task CreateBookingAsync(BookingDto dto)
    {
        var booking = _mapper.Map<Booking>(dto);
        await _repo.AddAsync(booking);
        await _notificationBuilder.NotifyBookingCreatedAsync(booking);
    }

    public async Task UpdateBookingAsync(BookingDto dto)
    {
        var existing = await _repo.GetByIdAsync(dto.BookingID);
        if (existing == null) return;

        var statusChanged = existing.BookingStatusId != dto.BookingStatusId;

        existing.BookingStatusId = dto.BookingStatusId;
        existing.ServiceDate = dto.ServiceDate;
        existing.UpdatedAt = DateTime.UtcNow;
        existing.Price = dto.Price;
        existing.Description = dto.Description;
        existing.PaymentMethod = dto.PaymentMethod;
        existing.IsPaid = dto.IsPaid;
        existing.ContactName = dto.ContactName;
        existing.Address = dto.Address;

        await _repo.UpdateAsync(existing);

      
        if (statusChanged)
        {
            var statusName = dto.BookingStatusName ?? $"Status ID {dto.BookingStatusId}";
            if (dto.BookingStatusId == 5)
            {
                await _notificationBuilder.NotifyBookingCancelledAsync(existing);
            }
            else
            {
                await _notificationBuilder.NotifyBookingStatusChangedAsync(existing, statusName);
            }
        }

    
        var existingEmployeeIds = existing.AssignedEmployees?.Select(e => e.EmployeeId).ToList() ?? new List<int>();
        var updatedEmployeeIds = dto.AssignedEmployeeIds ?? new List<int>();

        var newlyAssigned = updatedEmployeeIds.Except(existingEmployeeIds).ToList();
        var removed = existingEmployeeIds.Except(updatedEmployeeIds).ToList();

    
        foreach (var employeeId in newlyAssigned)
        {
            await _bookingEmployeeRepo.AddAsync(new BookingEmployee
            {
                BookingId = existing.BookingID,
                EmployeeId = employeeId,
                AssignedAt = DateTime.UtcNow,
                Notes = "Assigned via update"
            });

            await _notificationBuilder.NotifyAssignedEmployeeAsync(existing, $"You have been assigned to booking #{existing.BookingID}.", employeeId);
        }

        foreach (var employeeId in removed)
        {
            await _bookingEmployeeRepo.RemoveAsync(existing.BookingID, employeeId);

            await _notificationBuilder.NotifyAssignedEmployeeAsync(existing, $"You have been removed from booking #{existing.BookingID}.", employeeId);
        }
    }



    public async Task DeleteBookingAsync(int id) => await _repo.DeleteAsync(id);
}
