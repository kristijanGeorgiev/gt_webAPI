using HomeServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingEmployeeRepository
    {
        Task<IEnumerable<BookingEmployee>> GetAllAsync();
        Task AddAsync(BookingEmployee assignment);
        Task<bool> RemoveAsync(int bookingId, int employeeId);

    }
}
