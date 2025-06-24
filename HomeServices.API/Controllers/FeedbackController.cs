using HomeServices.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _service;

    public FeedbackController(IFeedbackService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? serviceId = null, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var feedbacks = await _service.GetAllAsync(serviceId, fromDate, toDate);
        return Ok(feedbacks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));
    [HttpGet("booking/{bookingId}")]
    public async Task<IActionResult> GetByBookingId(int bookingId)
    {
        var feedback = await _service.GetFeedbackByBookingIdAsync(bookingId);
        if (feedback == null)
            return NotFound();

        return Ok(feedback);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FeedbackDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FeedbackDto dto)
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
