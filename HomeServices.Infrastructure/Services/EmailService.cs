using HomeServices.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly string _apiKey;
    private readonly string _senderEmail;
    private readonly string _senderName;

    public EmailService(IConfiguration config)
    {
        _apiKey = config["SendGrid:ApiKey"];
        _senderEmail = config["SendGrid:SenderEmail"];
        _senderName = config["SendGrid:SenderName"];
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_senderEmail, _senderName);
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);

        var response = await client.SendEmailAsync(msg);

        System.Diagnostics.Debug.WriteLine($" SendGrid Response: {response.StatusCode}");

        if ((int)response.StatusCode >= 400)
        {
            var error = await response.Body.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine($" SendGrid Error: {error}");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(" Email accepted by SendGrid");
        }
    }
}
