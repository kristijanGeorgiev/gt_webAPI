using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Domain.Entities
{
    public class BookingStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
