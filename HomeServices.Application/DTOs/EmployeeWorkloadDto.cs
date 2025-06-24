using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class EmployeeWorkloadDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TotalJobsAssigned { get; set; }
    }
}
