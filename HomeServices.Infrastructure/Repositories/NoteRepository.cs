using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext _context;

        public NotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllAsync() =>
    await _context.Notes.Include(n => n.Booking).Include(n => n.Employee).ToListAsync();

        public async Task<Note?> GetByIdAsync(int id) =>
            await _context.Notes.Include(n => n.Booking).Include(n => n.Employee)
                                .FirstOrDefaultAsync(n => n.NotesId == id);
        public async Task<Note?> GetByBookingIdAsync(int bookingId, int? userId)
        {
            var query = _context.Notes.AsQueryable();

            query = query.Where(n => n.BookingId == bookingId);

            if (userId.HasValue)
            {
                query = query.Where(n => n.UserId == userId.Value);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}
