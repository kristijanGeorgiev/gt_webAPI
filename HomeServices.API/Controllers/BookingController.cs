using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingController(IBookingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
    [FromQuery] int? statusId,
    [FromQuery] bool? isPaid,
    [FromQuery] DateTime? fromDate,
    [FromQuery] DateTime? toDate)
    {
        var result = await _service.GetAllBookingsAsync(statusId, isPaid, fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetBookingByIdAsync(id));

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null, [FromQuery] int? statusId = null)
    {
        var bookings = await _service.GetBookingsByUserIdAsync(userId, fromDate, toDate, statusId);
        return Ok(bookings);
    }

    [HttpGet("status/{statusId}")]
    public async Task<IActionResult> GetByStatusId(int statusId)
    {
        var bookings = await _service.GetBookingsByStatusIdAsync(statusId);
        return Ok(bookings);
    }
    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetByAssignedEmployee(int employeeId, [FromQuery] string? status = null)
    {
        var result = await _service.GetBookingsByAssignedEmployeeAsync(employeeId, status);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookingDto dto)
    {
        await _service.CreateBookingAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BookingDto dto)
    {
        if (id != dto.BookingID)
            return BadRequest("Mismatched booking ID.");

        await _service.UpdateBookingAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteBookingAsync(id);
        return Ok();
    }
}
