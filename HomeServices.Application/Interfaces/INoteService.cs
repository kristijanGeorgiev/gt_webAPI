using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface INotesService
    {
        Task<IEnumerable<NoteDto>> GetAllAsync();
        Task<NoteDto?> GetByIdAsync(int id);
        Task<NoteDto?> GetByBookingIdAsync(int bookingId, int? userId);
        Task CreateAsync(NoteDto dto);
        Task UpdateAsync(NoteDto dto);
        Task DeleteAsync(int id);
    }

}
