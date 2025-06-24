using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class FeedbackDto
    {
        public int FeedbackID { get; set; }
        public int BookingID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string? ServiceName { get; set; }
        public DateTime ServiceDate { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
    }
}
