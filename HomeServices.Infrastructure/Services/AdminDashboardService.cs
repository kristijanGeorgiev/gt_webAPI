using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _repository;

        public AdminDashboardService(IUserRepository @object, IBookingRepository object1, IAdminDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdminDashboardDto> GetAdminDashboardDataAsync()
        {
            return new AdminDashboardDto
            {
                TotalClients = await _repository.CountClientsAsync(),
                TotalEmployees = await _repository.CountEmployeesAsync(),
                TotalBookings = await _repository.CountAllBookingsAsync(),
                TotalRevenue = await _repository.CalculateTotalRevenueAsync(),
                PendingBookings = await _repository.CountPendingBookingsAsync(),
                PendingInvoices = await _repository.CountPendingInvoicesAsync(),
                BookingsByServiceType = await _repository.GetBookingsByServiceAsync(),
                MonthlyBookingTrends = await _repository.GetMonthlyBookingTrendsAsync(),
                RevenueByMonth = await _repository.GetRevenueByMonthAsync()
            };
        }
    }
}
