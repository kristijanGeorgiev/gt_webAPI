using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IWorkPositionService
    {
        Task<IEnumerable<WorkPositionDto>> GetAllAsync();
        Task<WorkPositionDto> GetByIdAsync(int id);
        Task CreateAsync(WorkPositionDto dto);
        Task UpdateAsync(WorkPositionDto dto);
        Task DeleteAsync(int id);
    }
}
