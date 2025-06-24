using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class BookingsByServiceDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public int TotalBookings { get; set; }
    }

}
