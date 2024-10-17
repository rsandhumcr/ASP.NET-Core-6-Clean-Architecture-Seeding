using CompanyNameSpace.ProjectName.Api.Middleware;
using CompanyNameSpace.ProjectName.Api.Services;
using CompanyNameSpace.ProjectName.Api.Utility;
using CompanyNameSpace.ProjectName.Application;
using CompanyNameSpace.ProjectName.Application.Contracts;
using CompanyNameSpace.ProjectName.Application.Utils;
using CompanyNameSpace.ProjectName.Identity;
using CompanyNameSpace.ProjectName.Infrastructure;
using CompanyNameSpace.ProjectName.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Serilog;

namespace CompanyNameSpace.ProjectName.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        AddSwagger(builder.Services);

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddIdentityServices(builder.Configuration);

        builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();


        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });


        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyNameSpace ProjectName API");
            });
        }

        app.UseHttpsRedirection();

        //app.UseRouting();

        app.UseAuthentication();

        app.UseCustomExceptionHandler();

        app.UseCors("Open");

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "CompanyNameSpace ProjectName API"
            });

            c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<ProjectNameDbContext>();
            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            GeneralUtils.DebugWriteLineException(ex);
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }

    public static async Task InitialIdentityDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<ProjectNameIdentityDbContext>();
            if (context != null) await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            GeneralUtils.DebugWriteLineException(ex);
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occurred while inti identity database.");
        }

        /*
           // Json to create test user.
           {
             "firstName": "test",
             "lastName": "test",
             "email": "test@test.com",
             "userName": "testtest",
             "password": "Testtest1!"
           }
            // Json to Auth user
            {
             "email":  "test@test.com",
             "password": "Testtest1!"
            }
         */
    }
}