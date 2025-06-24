using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingStatusService
    {
        Task<IEnumerable<BookingStatusDto>> GetAllAsync();
        Task<BookingStatusDto> GetByIdAsync(int id);
        Task CreateAsync(BookingStatusDto dto);
        Task UpdateAsync(BookingStatusDto dto);
        Task DeleteAsync(int id);
    }
}
