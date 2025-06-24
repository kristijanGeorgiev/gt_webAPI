using HomeServices.Application.DTOs;
using HomeServices.Application.DTOs.HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using HomeServices.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    private readonly JwtTokenService _tokenService;
    private readonly IEmailService _emailService;
    public AuthController(IUserRepository userRepo, JwtTokenService tokenService, IEmailService emailService)
    {
        _userRepo = userRepo;
        _tokenService = tokenService;
        _emailService = emailService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = (await _userRepo.GetAllAsync())
            .FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user);

        return Ok(new
        {
            token,
            role = user.Role,
            userId = user.UserId,
            email = user.Email,
            username = user.Username,
            firstName = user.FirstName,
            lastName = user.LastName,
            address = user.Address
        });
    }
    [HttpPost("send-recovery-email")]
    public async Task<IActionResult> SendRecoveryEmail([FromBody] PasswordRecoveryRequestDto request)
    {
        var user = await _userRepo.FindByEmailAsync(request.Email);
        if (user == null)
            return BadRequest("User not found");

        var token = Guid.NewGuid().ToString();

        user.PasswordResetToken = token;
        user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);

        await _userRepo.UpdateAsync(user);

        var frontendUrl = "http://localhost:4200/resetpassword";
        var resetLink = $"{frontendUrl}?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

        await _emailService.SendEmailAsync(user.Email, "Password Reset",
            $"Click <a href='{resetLink}'>here</a> to reset your password.");

        return Ok();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
    {
        var user = await _userRepo.FindByEmailAsync(request.Email);
        if (user == null)
            return BadRequest("User not found");
        if (user.PasswordResetToken != request.Token || user.PasswordResetTokenExpiry < DateTime.UtcNow)
            return BadRequest("Invalid or expired token.");

        user.Password = request.NewPassword;
        user.PasswordResetToken = null;
        user.PasswordResetTokenExpiry = null;

        await _userRepo.UpdateAsync(user);

        return Ok("Password has been reset successfully.");
    }



}
