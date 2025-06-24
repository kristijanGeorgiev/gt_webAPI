using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IBookingEmployeeService
    {
        Task AssignEmployeeAsync(BookingEmployeeDto dto);
        Task RemoveAssignmentAsync(int bookingId, int employeeId);
        Task<IEnumerable<BookingEmployeeDto>> GetAssignmentsAsync();
    }
}
