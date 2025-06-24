using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;

    public UploadController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost, DisableRequestSizeLimit]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        try
        {
            if (file == null)
                return BadRequest("No file provided");

            var dbPath = await _uploadService.UploadImageAsync(file, "Images");
            return Ok(new { dbPath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
