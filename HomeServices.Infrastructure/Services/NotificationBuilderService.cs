using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class NotificationBuilderService : INotificationBuilderService
{
    private readonly INotificationRepository _notificationRepo;
    private readonly IUserRepository _userRepo;
    private readonly IEmailService _emailService;

    public NotificationBuilderService(
        INotificationRepository notificationRepo,
        IUserRepository userRepo,
        IEmailService emailService)
    {
        _notificationRepo = notificationRepo;
        _userRepo = userRepo;
        _emailService = emailService;
    }

    public async Task NotifyWelcomeToClientAsync(User client)
    {
        var admin = (await _userRepo.GetAllAsync()).FirstOrDefault(u => u.Role == "Admin" && u.Username == "admin");
        if (admin == null) return;

        var message = $"Welcome {client.FirstName}! Your account has been successfully created.";

        var notification = new Notification
        {
            UserID = client.UserId,
            FromUserID = admin.UserId,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(client.Email, "Welcome to HomeServices", message);
    }

    public async Task NotifyBookingCreatedAsync(Booking booking)
    {
        var client = await _userRepo.GetByIdAsync(booking.UserID);
        var admin = (await _userRepo.GetByIdAsync(1));
        var message = $"New booking has been created by {client.FirstName} {client.LastName}.";
        var notification = new Notification
        {
                UserID = admin.UserId,
                FromUserID = client.UserId,
                Message = message,
                CreatedAt = DateTime.UtcNow
        };
        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(admin.Email, "New Booking Created", message);
    }

    public async Task NotifyBookingStatusChangedAsync(Booking booking, string newStatus)
    {
        if (booking == null) return;

        var admin = await _userRepo.GetByIdAsync(1);
        var client = await _userRepo.GetByIdAsync(booking.UserID);
        if (client == null || admin == null) return;

        var message = $"Your booking #{booking.BookingID} status has been updated to: {newStatus}";

        var notification = new Notification
        {
            UserID = client.UserId,
            FromUserID = admin.UserId,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(client.Email, "Booking Status Updated", message);
    }

    public async Task NotifyAssignedEmployeeAsync(Booking booking, string message, int employeeId)
    {
        var employee = await _userRepo.GetByIdAsync(employeeId);
        if (employee == null) return;

        var notification = new Notification
        {
            UserID = employee.UserId,
            FromUserID = 1,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(employee.Email, "Booking Assignment Update", message);
    }

    public async Task NotifyFeedbackAddedAsync(int clientUserId, string message)
    {
        var admin = await _userRepo.GetByIdAsync(1);
        var client = await _userRepo.GetByIdAsync(clientUserId);
        if (admin == null || client == null) return;

        var notification = new Notification
        {
            UserID = admin.UserId,
            FromUserID = client.UserId,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(admin.Email, "New Feedback Submitted", message);
    }

    public async Task NotifyBookingCancelledAsync(Booking booking)
    {
        var client = await _userRepo.GetByIdAsync(booking.UserID);
        var admin = await _userRepo.GetByIdAsync(1);
        if (client == null || admin == null) return;

        var message = $"Booking #{booking.BookingID} has been cancelled by {client.FirstName}.";

        var notification = new Notification
        {
            UserID = admin.UserId,
            FromUserID = client.UserId,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepo.AddAsync(notification);
        await _emailService.SendEmailAsync(admin.Email, "Booking Cancelled", message);
    }
}

