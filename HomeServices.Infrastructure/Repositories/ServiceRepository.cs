using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services.ToListAsync();
    }


    public async Task<Service> GetByIdAsync(int id) =>
        await _context.Services.FindAsync(id);

    public async Task AddAsync(Service entity)
    {
        await _context.Services.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Service entity)
    {
        _context.Services.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Services.FindAsync(id);
        if (entity != null)
        {
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
