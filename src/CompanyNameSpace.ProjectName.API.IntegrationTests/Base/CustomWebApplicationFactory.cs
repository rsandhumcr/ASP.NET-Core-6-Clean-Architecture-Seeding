using CompanyNameSpace.ProjectName.Application.Utils;
using CompanyNameSpace.ProjectName.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CompanyNameSpace.ProjectName.API.IntegrationTests.Base;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<ProjectNameDbContext>(options =>
            {
                options.UseInMemoryDatabase("ProjectNameDbContextInMemoryTest");
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ProjectNameDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                context.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(context);
                }
                catch (Exception ex)
                {
                    var errorMsg = GeneralUtils.FormatException(ex);
                    logger.LogError(ex,
                        $"An error occurred seeding the database with test messages. Error: {errorMsg}");
                }
            }

            ;
        });
    }

    public HttpClient GetAnonymousClient()
    {
        return CreateClient();
    }
}