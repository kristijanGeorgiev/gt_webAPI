using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class BookingEmployeeDto
    {
        public int BookingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AssignedAt { get; set; }
        public string Notes { get; set; }
    }
}
