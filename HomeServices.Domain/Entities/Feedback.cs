using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Domain.Entities
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int BookingID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Booking Booking { get; set; }
    }
}
