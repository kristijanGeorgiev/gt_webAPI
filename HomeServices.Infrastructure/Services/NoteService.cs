using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;

namespace HomeServices.Infrastructure.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _repo;
        private readonly IMapper _mapper;

        public NotesService(INotesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<NoteDto>>(await _repo.GetAllAsync());

        public async Task<NoteDto?> GetByIdAsync(int id) =>
            _mapper.Map<NoteDto?>(await _repo.GetByIdAsync(id));
        public async Task<NoteDto?> GetByBookingIdAsync(int bookingId, int? userId)
        {
            var note = await _repo.GetByBookingIdAsync(bookingId, userId);
            return _mapper.Map<NoteDto?>(note);
        }
        public async Task CreateAsync(NoteDto dto) =>
            await _repo.AddAsync(_mapper.Map<Note>(dto));

        public async Task UpdateAsync(NoteDto dto) =>
            await _repo.UpdateAsync(_mapper.Map<Note>(dto));

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);
    }
}