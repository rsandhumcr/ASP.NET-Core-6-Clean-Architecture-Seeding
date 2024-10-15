using CompanyNameSpace.ProjectName.Application.Models.Mail;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
