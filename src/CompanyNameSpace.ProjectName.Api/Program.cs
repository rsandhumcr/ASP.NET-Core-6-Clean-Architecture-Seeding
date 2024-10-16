using Serilog;
using CompanyNameSpace.ProjectName.Api;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("ProjectName API starting");

var builder = WebApplication.CreateBuilder(args);

var testModeConfigValue = builder.Configuration.GetValue<string>("IntegrationTestMode");
var isInTest = testModeConfigValue.Equals("true");


builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration), isInTest);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.UseSerilogRequestLogging();

// Resets the database when executed
// ProjectNameDb
await app.ResetDatabaseAsync();

// Populate the Identity database when executed
// ProjectNameIdentityDb
await app.InitialIdentityDatabaseAsync();

app.Run();

public partial class Program { }

