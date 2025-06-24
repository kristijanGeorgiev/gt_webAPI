using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public interface IEmployeeStatisticService
    {
        Task<EmployeeStatisticDto> GetStatisticsForEmployeeAsync(int employeeId);
    }

}
