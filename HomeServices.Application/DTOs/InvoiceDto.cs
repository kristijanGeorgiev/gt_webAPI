using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class InvoiceDto
    {
        public int InvoiceID { get; set; }
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public int Tax { get; set; }

        public int Quantity { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? ServiceName { get; set; }
    }
}
