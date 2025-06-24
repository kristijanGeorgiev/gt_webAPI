using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetByAssignedEmployeeAsync(int employeeId, string? status);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
    }
}
