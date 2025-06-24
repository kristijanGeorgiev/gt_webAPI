using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Services
{
    public class EmployeeReportsService : IEmployeeReportsService
    {
        private readonly IEmployeeReportsRepository _repo;

        public EmployeeReportsService(IEmployeeReportsRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EmployeeCombinedReportDto>> GetEmployeeCombinedReportAsync()
        {
            return await _repo.GetEmployeeCombinedReportAsync();
        }
    }

}
