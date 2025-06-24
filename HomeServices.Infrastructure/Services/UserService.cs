using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IBookingRepository _bookingrepo;
    private readonly IMapper _mapper;
    private readonly INotificationBuilderService _notificationBuilder;

    public UserService(IUserRepository repo, IBookingRepository bookingrepo, IMapper mapper, INotificationBuilderService notificationBuilder)
    {
        _repo = repo;
        _bookingrepo = bookingrepo;
        _mapper = mapper;
        _notificationBuilder = notificationBuilder;
    }

    public async Task<IEnumerable<ClientDto>> GetAllClientsAsync() =>
        _mapper.Map<IEnumerable<ClientDto>>((await _repo.GetAllAsync()).Where(u => u.Role == "Client"));

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = (await _repo.GetAllAsync())
            .Where(u => u.Role == "Employee")
            .ToList();

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }


    public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync() =>
        _mapper.Map<IEnumerable<AdminDto>>((await _repo.GetAllAsync()).Where(u => u.Role == "Admin"));

    public async Task<ClientDto> GetClientByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user?.Role == "Client" ? _mapper.Map<ClientDto>(user) : null;
    }
    public async Task<IEnumerable<EmployeeDto>> GetAvailableEmployeesAsync(
        int? workPositionId, bool? isAvailable, DateTime? serviceDate)
    {
        var users = await _repo.GetAllAsync();
        var employees = users.Where(u => u.Role == "Employee");

        if (workPositionId.HasValue)
            employees = employees.Where(e => e.WorkPositionId == workPositionId.Value);

        if (isAvailable.HasValue)
            employees = employees.Where(e => e.Available == isAvailable.Value);

        if (serviceDate.HasValue)
        {
            var bookingsOnDate = await _bookingrepo.GetAllAsync();
            var matchedBookings = bookingsOnDate
                .Where(b => b.ServiceDate.Date == serviceDate.Value.Date);

            var busyEmployeeIds = matchedBookings
                .SelectMany(b => b.AssignedEmployees)
                .Select(ae => ae.EmployeeId)
                .Distinct()
                .ToHashSet();

            employees = employees.Where(e => !busyEmployeeIds.Contains(e.UserId));
        }

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }


    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user?.Role == "Employee" ? _mapper.Map<EmployeeDto>(user) : null;
    }

    public async Task<AdminDto> GetAdminByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user?.Role == "Admin" ? _mapper.Map<AdminDto>(user) : null;
    }


    public async Task CreateUserAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            Role = dto.Role,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            WorkPositionId = dto.WorkPositionId
        };

        await _repo.AddAsync(user);
    
        await _notificationBuilder.NotifyWelcomeToClientAsync(user);
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;
        user.Address = dto.Address;
        user.DateOfBirth = dto.DateOfBirth;
        user.WorkPositionId = dto.WorkPositionId;

        await _repo.UpdateAsync(user);
    }
    public async Task DeleteUserAsync(int id) =>
        await _repo.DeleteAsync(id);
}
