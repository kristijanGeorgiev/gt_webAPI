using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class AdminDashboardDto
    {
        public int TotalClients { get; set; }

        public int TotalEmployees { get; set; }
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public int PendingBookings { get; set; }
        public int PendingInvoices { get; set; }

        public List<BookingsByServiceDto> BookingsByServiceType { get; set; } = new();
        public List<MonthlyBookingDto> MonthlyBookingTrends { get; set; } = new();
        public List<RevenueByMonthDto> RevenueByMonth { get; set; } = new();
    }

}
