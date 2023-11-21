using GlobalTeknoloji.Data.Context;
using GlobalTeknoloji.Job;
using GlobalTeknoloji.Job.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using GlobalTeknoloji.IoC;

#region .:| Add services to the container. |:.

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("LogFiles/BitcoinInfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddResponseCaching();
builder.Services.AddDbContext<GTDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("GTConnectionString"));
});
builder.Services.AddHostedService<CallBitcoinApi>();
builder.Services.AddAuthentication("Bearer");
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });

DependenciesInjection.InjectServices(builder.Services);

#endregion


#region .:| Config App |:.

var app = builder.Build();

GlobalTeknoloji.Infrastructure.Utilities.GTHelper.Logger = app.Logger;

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();
app.MapControllers();

app.Run();

#endregion

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    //endpoints.MapControllerRoute("default", "{controller}");
//    //endpoints.MapControllerRoute("alternative", "{controller}/{action}");
//});
