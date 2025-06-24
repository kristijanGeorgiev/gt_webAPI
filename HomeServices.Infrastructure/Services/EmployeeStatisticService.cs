using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

public class EmployeeStatisticService : IEmployeeStatisticService
{
    private readonly IBookingRepository _bookingRepo;
    private readonly IFeedbackRepository _feedbackRepo;
    private readonly INotesRepository _notesRepo;
    private readonly IUserRepository _userRepo;

    public EmployeeStatisticService(
        IBookingRepository bookingRepo,
        IFeedbackRepository feedbackRepo,
        INotesRepository notesRepo,
        IUserRepository userRepo)
    {
        _bookingRepo = bookingRepo;
        _feedbackRepo = feedbackRepo;
        _notesRepo = notesRepo;
        _userRepo = userRepo;
    }

    public async Task<EmployeeStatisticDto> GetStatisticsForEmployeeAsync(int employeeId)
    {
        var now = DateTime.Now;
        var currentYear = now.Year;
        var currentMonth = now.Month;

        var employee = await _userRepo.GetByIdAsync(employeeId);
        if (employee == null || employee.Role != "Employee")
            throw new Exception("Employee not found or invalid role.");

        var allBookings = await _bookingRepo.GetAllAsync();
        var completedBookings = allBookings
            .Where(b => b.AssignedEmployees.Any(a => a.EmployeeId == employeeId)
                     && (b.BookingStatusName == "Completed" || b.BookingStatusName == "Closed"));

        var completedJobsThisYear = completedBookings
            .Count(b => b.BookingDate.Year == currentYear);

        var completedJobsThisMonth = completedBookings
            .Count(b => b.BookingDate.Year == currentYear && b.BookingDate.Month == currentMonth);

        var notes = await _notesRepo.GetAllAsync();
        var employeeNotes = notes
            .Where(n => n.UserId == employeeId && n.Booking != null);

        var workingHoursThisYear = employeeNotes
            .Where(n => n.Booking.BookingDate.Year == currentYear)
            .Sum(n => (n.CheckOut - n.CheckIn).TotalHours);

        var workingHoursThisMonth = employeeNotes
            .Where(n => n.Booking.BookingDate.Year == currentYear && n.Booking.BookingDate.Month == currentMonth)
            .Sum(n => (n.CheckOut - n.CheckIn).TotalHours);

        var feedbacks = await _feedbackRepo.GetAllEntitiesAsync();
        var employeeFeedbacks = feedbacks
            .Where(f => f.Booking != null &&
                        f.Booking.AssignedEmployees.Any(e => e.EmployeeId == employeeId) &&
                        f.Booking.BookingDate.Year == currentYear);

        return new EmployeeStatisticDto
        {
            EmployeeId = employeeId,
            EmployeeName = $"{employee.FirstName} {employee.LastName}",
            CompletedJobsThisYear = completedJobsThisYear,
            CompletedJobsThisMonth = completedJobsThisMonth,
            WorkingHoursThisYear = workingHoursThisYear,
            WorkingHoursThisMonth = workingHoursThisMonth,
            AverageRatingThisYear = employeeFeedbacks.Any() ? employeeFeedbacks.Average(f => f.Rating) : 0
        };
    }

}
