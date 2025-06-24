using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public FeedbackRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FeedbackDto>> GetAllAsync()
    {
        var query = _context.Feedbacks
            .Include(f => f.Booking)
                .ThenInclude(b => b.Service)
            .AsQueryable();
        return _mapper.Map<IEnumerable<FeedbackDto>>(query);
    }

    public async Task<IEnumerable<Feedback>> GetAllEntitiesAsync()
    {
        return await _context.Feedbacks
            .Include(f => f.Booking)
                .ThenInclude(b => b.AssignedEmployees)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetAllWithBookingAsync()
    {
        return await _context.Feedbacks
            .Include(f => f.Booking)
            .ToListAsync();
    }

    public async Task<Feedback?> GetByIdAsync(int id)
    {
        return await _context.Feedbacks
       .Include(f => f.Booking)
           .ThenInclude(b => b.Service)
       .FirstOrDefaultAsync(f => f.FeedbackID == id);
    }

    public async Task<Feedback?> GetByBookingIdAsync(int bookingId)
    {
        return await _context.Feedbacks
       .Include(f => f.Booking)
           .ThenInclude(b => b.Service)
       .FirstOrDefaultAsync(f => f.BookingID == bookingId);
    }


    public async Task<Feedback?> GetAsync(Expression<Func<Feedback, bool>> predicate)
    {
        return await _context.Feedbacks.FirstOrDefaultAsync(predicate);
    }


    public async Task AddAsync(Feedback entity)
    {
        Console.WriteLine("Saving Notification to DB...");
        await _context.Feedbacks.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Feedback entity)
    {
        _context.Feedbacks.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Feedbacks.FindAsync(id);
        if (entity != null)
        {
            _context.Feedbacks.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
