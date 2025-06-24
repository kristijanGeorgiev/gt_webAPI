using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class EmployeeStatisticDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public int CompletedJobsThisYear { get; set; }
        public int CompletedJobsThisMonth { get; set; }
        public double WorkingHoursThisYear { get; set; }
        public double WorkingHoursThisMonth { get; set; }

        public double AverageRatingThisYear { get; set; }
    }


}
