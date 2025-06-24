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
    public class EmployeeReportsRepository : IEmployeeReportsRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeReportsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeCombinedReportDto>> GetEmployeeCombinedReportAsync()
        {

            var workload = await _context.BookingEmployees
                .GroupBy(be => be.EmployeeId)
                .Select(g => new
                {
                    EmployeeId = g.Key,
                    TotalJobsAssigned = g.Count()
                })
                .ToListAsync();

            var notes = _context.Notes
            .Where(n => n.CheckIn != null && n.CheckOut != null)
            .AsEnumerable()
            .GroupBy(n => n.UserId)
            .Select(g => new
              {
                    EmployeeId = g.Key,
                    TotalHoursWorked = g.Sum(n => (n.CheckOut - n.CheckIn).TotalHours)
              }).ToList();

            var employees = await _context.Users
                .Where(u => u.Role == "Employee")
                .Select(u => new
                {
                    u.UserId,
                    u.FirstName,
                    u.LastName
                })
                .ToListAsync();

            var result = employees
                .GroupJoin(workload,
                    e => e.UserId,
                    w => w.EmployeeId,
                    (e, wGroup) => new { e, wGroup })
                .SelectMany(
                    ew => ew.wGroup.DefaultIfEmpty(),
                    (ew, w) => new { ew.e, Workload = w })
                .GroupJoin(notes,
                    ew => ew.e.UserId,
                    n => n.EmployeeId,
                    (ew, nGroup) => new { ew, nGroup })
                .SelectMany(
                    ewn => ewn.nGroup.DefaultIfEmpty(),
                    (ewn, n) => new EmployeeCombinedReportDto
                    {
                        EmployeeId = ewn.ew.e.UserId,
                        EmployeeName = $"{ewn.ew.e.FirstName} {ewn.ew.e.LastName}",
                        TotalJobsAssigned = ewn.ew.Workload?.TotalJobsAssigned ?? 0,
                        TotalHoursWorked = n?.TotalHoursWorked ?? 0
                    })
                .OrderByDescending(r => r.TotalJobsAssigned)
                .ToList();

            return result;
        }

    }
}