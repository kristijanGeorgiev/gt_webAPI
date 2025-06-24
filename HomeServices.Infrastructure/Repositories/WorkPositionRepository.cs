using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class WorkPositionRepository : IWorkPositionRepository
{
    private readonly ApplicationDbContext _context;

    public WorkPositionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkPosition>> GetAllAsync() =>
        await _context.WorkPositions.ToListAsync();

    public async Task<WorkPosition> GetByIdAsync(int id) =>
        await _context.WorkPositions.FindAsync(id);

    public async Task AddAsync(WorkPosition entity)
    {
        await _context.WorkPositions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WorkPosition entity)
    {
        _context.WorkPositions.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.WorkPositions.FindAsync(id);
        if (entity != null)
        {
            _context.WorkPositions.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
