using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync(int? statusId, bool? isPaid, DateTime? fromDate, DateTime? toDate);
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(int userId, DateTime? fromDate = null, DateTime? toDate = null, int? statusId = null);
        Task<IEnumerable<BookingDto>> GetBookingsByAssignedEmployeeAsync(int employeeId, string? status = null);

        Task<IEnumerable<BookingDto>> GetBookingsByStatusIdAsync(int statusId);
        Task CreateBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(BookingDto bookingDto);
        Task DeleteBookingAsync(int id);
    }
}
