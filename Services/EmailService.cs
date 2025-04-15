using System.Net;
using System.Net.Mail;
using DotNetEnv;

namespace CollegeFeedbackPlatform.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;

    public EmailService()
    {
        Env.Load();

        _fromEmail = Environment.GetEnvironmentVariable("SMTP_EMAIL");
        var smptHost = Environment.GetEnvironmentVariable("SMTP_HOST");
        var smptPort = Environment.GetEnvironmentVariable("SMTP_PORT");
        var smptPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");

        _smtpClient = new SmtpClient(smptHost, Convert.ToInt32(smptPort))
        {
            Credentials = new NetworkCredential(_fromEmail, smptPassword),
            EnableSsl = true
        };
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var mail = new MailMessage(_fromEmail, toEmail, subject, body);
        await _smtpClient.SendMailAsync(mail);
    }
}