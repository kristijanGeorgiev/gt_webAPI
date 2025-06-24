using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Domain.Entities
{
    public class BookingEmployee
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int EmployeeId { get; set; }
        public User Employee { get; set; }

        public DateTime AssignedAt { get; set; }
        public string Notes { get; set; }
    }
}
