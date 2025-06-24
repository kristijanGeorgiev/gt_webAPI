using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class EmployeeHoursWorkedDto
    {
        public int UserId { get; set; }
        public string EmployeeName { get; set; }
        public double TotalHoursWorked { get; set; }
    }
}
