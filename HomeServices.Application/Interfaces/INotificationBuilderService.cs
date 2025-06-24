using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface INotificationBuilderService
    {
        Task NotifyWelcomeToClientAsync(User client);
        Task NotifyBookingCreatedAsync(Booking booking);
        Task NotifyBookingStatusChangedAsync(Booking booking, string newStatus);
        Task NotifyAssignedEmployeeAsync(Booking booking, string message, int employeeId);
        Task NotifyFeedbackAddedAsync(int clientUserId, string message);
        Task NotifyBookingCancelledAsync(Booking booking);
    }

}
