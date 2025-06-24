using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingStatusRepository
    {
        Task<IEnumerable<BookingStatus>> GetAllAsync();
        Task<BookingStatus> GetByIdAsync(int id);
        Task AddAsync(BookingStatus status);
        Task UpdateAsync(BookingStatus status);
        Task DeleteAsync(int id);
    }
}
