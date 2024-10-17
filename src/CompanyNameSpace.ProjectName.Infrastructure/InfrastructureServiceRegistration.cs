using CompanyNameSpace.ProjectName.Application.Contracts.Infrastructure;
using CompanyNameSpace.ProjectName.Application.Models.Mail;
using CompanyNameSpace.ProjectName.Infrastructure.FileExport;
using CompanyNameSpace.ProjectName.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyNameSpace.ProjectName.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<ICsvExporter, CsvExporter>();
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}