namespace HomeServices.Application.DTOs
{
    public class NoteDto
    {
        public int NotesId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }

        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }

        public string NoteText { get; set; } = string.Empty;
    }
}

