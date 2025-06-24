using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Repositories
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountClientsAsync()
        {
            return await _context.Users.CountAsync(u => u.Role == "Client");
        }

        public async Task<int> CountEmployeesAsync()
        {
            return await _context.Users.CountAsync(u => u.Role == "Employee");
        }

        public async Task<int> CountAllBookingsAsync()
        {
            return await _context.Bookings.CountAsync();
        }

        public async Task<decimal> CalculateTotalRevenueAsync()
        {
            return await _context.Invoices.Where(b => b.IsPaid).SumAsync(b => b.Quantity * b.Amount + b.Quantity * b.Amount * b.Tax / 100);
        }

        public async Task<int> CountPendingBookingsAsync()
        {
            return await _context.Bookings.CountAsync(b => b.BookingStatusId == 1);
        }

        public async Task<int> CountPendingInvoicesAsync()
        {
            return await _context.Invoices.CountAsync(i => !i.IsPaid);
        }

        public async Task<List<BookingsByServiceDto>> GetBookingsByServiceAsync()
        {
            return await _context.Bookings
                .Where(b => b.Service != null)
                .GroupBy(b => b.Service.Name)
                .Select(g => new BookingsByServiceDto
                {
                    ServiceName = g.Key,
                    TotalBookings = g.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MonthlyBookingDto>> GetMonthlyBookingTrendsAsync()
        {
            var query = await _context.Bookings
                .GroupBy(b => new { b.BookingDate.Year, b.BookingDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalBookings = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToListAsync();

            return query.Select(g => new MonthlyBookingDto
            {
                Month = $"{g.Year}-{g.Month:D2}",
                TotalBookings = g.TotalBookings
            })
            .ToList();
        }


        public async Task<List<RevenueByMonthDto>> GetRevenueByMonthAsync()
        {
            var query = await _context.Invoices
        .GroupBy(b => new { b.IssuedDate.Year, b.IssuedDate.Month })
        .Select(g => new
        {
            Year = g.Key.Year,
            Month = g.Key.Month,
            TotalRevenue = g.Sum(e => e.Quantity*e.Amount*(1+e.Tax/100))
        })
        .OrderBy(g => g.Year)
        .ThenBy(g => g.Month)
        .ToListAsync();

            return query.Select(g => new RevenueByMonthDto
            {
                Month = $"{g.Year}-{g.Month:D2}",
                TotalRevenue = g.TotalRevenue
            })
            .ToList();
        }
    }
}