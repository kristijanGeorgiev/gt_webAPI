using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/test-email")]
[ApiController]
public class EmailTestController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailTestController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet]
    public async Task<IActionResult> SendTest()
    {
        await _emailService.SendEmailAsync("youremail@example.com", "Test Email", "This is a test.");
        return Ok("Email sent (check console for confirmation)");
    }
}
