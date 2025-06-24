using HomeServices.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(INotificationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(
    int userId,
    [FromQuery] DateTime? fromDate,
    [FromQuery] DateTime? toDate)
    {
        var result = await _service.GetByUserIdAsync(userId, fromDate, toDate);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NotificationDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] NotificationDto dto)
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
