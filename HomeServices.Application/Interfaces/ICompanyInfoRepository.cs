using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface ICompanyInfoRepository
    {
        Task<IEnumerable<CompanyInfo>> GetAllAsync();
        Task<CompanyInfo?> GetByIdAsync(int id);
        Task AddAsync(CompanyInfo companyInfo);
        Task UpdateAsync(CompanyInfo companyInfo);
        Task DeleteAsync(int id);
    }
}
