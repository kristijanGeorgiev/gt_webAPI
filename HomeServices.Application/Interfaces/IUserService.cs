using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ClientDto>> GetAllClientsAsync();
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
        Task<IEnumerable<EmployeeDto>> GetAvailableEmployeesAsync(int? workPositionId, bool? isAvailable, DateTime? serviceDate);
        Task<ClientDto> GetClientByIdAsync(int id);
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<AdminDto> GetAdminByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto userDto);
        Task UpdateUserAsync(int id, UpdateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
