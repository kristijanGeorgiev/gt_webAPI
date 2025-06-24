using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("clients")]
    public async Task<IActionResult> GetClients() => Ok(await _service.GetAllClientsAsync());

    [HttpGet("employees")]
    public async Task<IActionResult> GetEmployees() => Ok(await _service.GetAllEmployeesAsync());

    [HttpGet("admins")]
    public async Task<IActionResult> GetAdmins() => Ok(await _service.GetAllAdminsAsync());
    [HttpGet("clients/{id}")]
    public async Task<IActionResult> GetClientById(int id)
    {
        var client = await _service.GetClientByIdAsync(id);
        return client == null ? NotFound() : Ok(client);
    }

    [HttpGet("employees/{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _service.GetEmployeeByIdAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }

    [HttpGet("admins/{id}")]
    public async Task<IActionResult> GetAdminById(int id)
    {
        var admin = await _service.GetAdminByIdAsync(id);
        return admin == null ? NotFound() : Ok(admin);
    }

    [HttpGet("available-employees")]
    public async Task<IActionResult> GetAvailableEmployees(
    [FromQuery] int? workPositionId = null,
    [FromQuery] bool? isAvailable = null,
    [FromQuery] DateTime? serviceDate = null)
    {
        var employees = await _service.GetAvailableEmployeesAsync(workPositionId, isAvailable, serviceDate);
        return Ok(employees);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.CreateUserAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateUserDto dto)
    {
        await _service.UpdateUserAsync(id, dto);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteUserAsync(id);
        return Ok();
    }
}
