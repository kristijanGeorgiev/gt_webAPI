using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Domain.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingStatusId { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public int? AdministratorID { get; set; }

        public ICollection<BookingEmployee> AssignedEmployees { get; set; }
    }
}
