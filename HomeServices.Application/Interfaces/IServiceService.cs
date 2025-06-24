using HomeServices.Application.DTOs;

public interface IServiceService
{
    Task<IEnumerable<ServiceDto>> GetAllAsync();
    Task<ServiceDto> GetByIdAsync(int id);
    Task CreateAsync(ServiceDto dto);
    Task UpdateAsync(ServiceDto dto);
    Task DeleteAsync(int id);
}
