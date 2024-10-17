using System.Net;
using CompanyNameSpace.ProjectName.Application.Contracts.Infrastructure;
using CompanyNameSpace.ProjectName.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CompanyNameSpace.ProjectName.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
    {
        _emailSettings = mailSettings.Value;
        _logger = logger;
    }

    public EmailSettings _emailSettings { get; }
    public ILogger<EmailService> _logger { get; }

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;

        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);

        _logger.LogInformation("Email sent");

        if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            return true;

        _logger.LogError("Email sending failed");

        return false;
    }
}