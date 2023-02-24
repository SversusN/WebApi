using System.Text.Json.Serialization;
using CustomerService.Helpers;
using CustomerService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerService", Version = "v1" });      
    });
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddLogging(logging =>
    {

        logging.AddConsole();
        logging.AddDebug();

    });
    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IServiceSalService, ServiceSalService>();
    services.AddScoped<IFilialService, FilialService>();

}

var app = builder.Build();
//var loggerFactory = app.Services.GetService<ILoggerFactory>();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();


    app.MapControllers();
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.Run("http://localhost:4000");