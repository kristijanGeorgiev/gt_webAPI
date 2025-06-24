using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class BookingDto
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int ServiceID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public int BookingStatusId { get; set; }
        public string? BookingStatusName { get; set; }
        public string? ServiceName { get; set; }

        public List<AssignedEmployeeDto> AssignedEmployees { get; set; } = new();

        public List<int> AssignedEmployeeIds { get; set; } = new();
    }

}
