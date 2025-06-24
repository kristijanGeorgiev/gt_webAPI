using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookingEmployeeController : ControllerBase
{
    private readonly IBookingEmployeeService _service;

    public BookingEmployeeController(IBookingEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAssignmentsAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookingEmployeeDto dto)
    {
        await _service.AssignEmployeeAsync(dto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int bookingId, int employeeId)
    {
        await _service.RemoveAssignmentAsync(bookingId, employeeId);
        return Ok();
    }
}
