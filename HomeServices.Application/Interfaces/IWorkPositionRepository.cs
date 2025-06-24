using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IWorkPositionRepository
    {
        Task<IEnumerable<WorkPosition>> GetAllAsync();
        Task<WorkPosition> GetByIdAsync(int id);
        Task AddAsync(WorkPosition position);
        Task UpdateAsync(WorkPosition position);
        Task DeleteAsync(int id);
    }
}
