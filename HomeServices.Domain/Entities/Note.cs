using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Domain.Entities
{
    public class Note
    {
        public int NotesId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }

        public TimeOnly CheckIn { get; set; }
        public TimeOnly CheckOut { get; set; }

        public string NoteText { get; set; } = string.Empty;

        public Booking Booking { get; set; } = null!;
        public User Employee { get; set; } = null!;
    }
}
