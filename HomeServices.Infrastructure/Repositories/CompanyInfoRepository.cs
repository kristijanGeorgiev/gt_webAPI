using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Repositories
{
    using HomeServices.Application.Interfaces;
    using HomeServices.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllAsync() =>
            await _context.Set<CompanyInfo>().ToListAsync();

        public async Task<CompanyInfo?> GetByIdAsync(int id) =>
            await _context.Set<CompanyInfo>().FindAsync(id);

        public async Task AddAsync(CompanyInfo companyInfo)
        {
            await _context.Set<CompanyInfo>().AddAsync(companyInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyInfo companyInfo)
        {
            _context.Set<CompanyInfo>().Update(companyInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<CompanyInfo>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<CompanyInfo>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
