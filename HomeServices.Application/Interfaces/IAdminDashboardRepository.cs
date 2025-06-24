using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IAdminDashboardRepository
    {
        Task<int> CountClientsAsync();

        Task<int> CountEmployeesAsync();
        Task<int> CountAllBookingsAsync();
        Task<decimal> CalculateTotalRevenueAsync();
        Task<int> CountPendingBookingsAsync();
        Task<int> CountPendingInvoicesAsync();

        Task<List<BookingsByServiceDto>> GetBookingsByServiceAsync();
        Task<List<MonthlyBookingDto>> GetMonthlyBookingTrendsAsync();
        Task<List<RevenueByMonthDto>> GetRevenueByMonthAsync();
    }
}
