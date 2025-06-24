using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkPositionController : ControllerBase
{
    private readonly IWorkPositionService _service;

    public WorkPositionController(IWorkPositionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WorkPositionDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] WorkPositionDto dto)
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