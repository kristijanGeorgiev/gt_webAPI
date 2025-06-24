using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Services
{
    public class AdminStatisticService : IAdminStatisticService
    {
        private readonly IUserRepository _userRepo;
        private readonly IBookingRepository _bookingRepo;

        public AdminStatisticService(IUserRepository userRepo, IBookingRepository bookingRepo)
        {
            _userRepo = userRepo;
            _bookingRepo = bookingRepo;
        }

        public async Task<AdminStatisticDto> GetAdminStatisticsAsync()
        {
            var currentDate = DateTime.Now;
            var allUsers = await _userRepo.GetAllAsync();
            var allBookings = await _bookingRepo.GetAllAsync();

            return new AdminStatisticDto
            {
                TotalNumberOfClients = allUsers.Count(u => u.Role == "Client"),
                TotalNumberOfPendingBookings = allBookings.Count(b => b.BookingStatusId == 1), // Assuming 1 = Pending
                TotalNumberOfBookingsForCurrentYear = allBookings.Count(b => b.BookingDate.Year == currentDate.Year),
                TotalNumberOfBookingsForCurrentMonth = allBookings.Count(b =>
                    b.BookingDate.Year == currentDate.Year &&
                    b.BookingDate.Month == currentDate.Month)
            };
        }
    }

}
