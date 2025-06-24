using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class AdminStatisticDto
    {
        public int TotalNumberOfClients { get; set; }
        public int TotalNumberOfPendingBookings { get; set; }
        public int TotalNumberOfBookingsForCurrentYear { get; set; }
        public int TotalNumberOfBookingsForCurrentMonth { get; set; }
    }

}
