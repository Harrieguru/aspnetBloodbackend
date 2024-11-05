using Microsoft.EntityFrameworkCore;
using webAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection of donationdb context
builder.Services.AddDbContext<DonationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Docker configuration - ensure this is outside any environment checks
app.Urls.Add("http://0.0.0.0:80");

// Configure Swagger - remove the environment check to always enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    // Set Swagger as the default page
    c.RoutePrefix = string.Empty;
});

// CORS should be enabled before Authorization
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();