using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyNameSpace.ProjectName.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IDataProcessor, DataProcessor>();

        return services;
    }
}