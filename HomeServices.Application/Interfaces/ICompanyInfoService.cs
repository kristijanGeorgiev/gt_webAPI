using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface ICompanyInfoService
    {
        Task<IEnumerable<CompanyInfoDto>> GetAllAsync();
        Task<CompanyInfoDto?> GetByIdAsync(int id);
        Task AddAsync(CompanyInfoDto dto);
        Task UpdateAsync(CompanyInfoDto dto);
        Task DeleteAsync(int id);
    }
}
