using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesService _service;

    public NotesController(INotesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var note = await _service.GetByIdAsync(id);
        return note == null ? NotFound() : Ok(note);
    }
    [HttpGet("booking/{bookingId}")]
    public async Task<IActionResult> GetByBookingId(int bookingId, [FromQuery] int? userId = null)
    {
        var note = await _service.GetByBookingIdAsync(bookingId, userId);
        if (note == null)
            return NotFound();

        return Ok(note);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NoteDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] NoteDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
