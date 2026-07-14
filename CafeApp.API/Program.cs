using CafeApp.Infrastructure;
using CafeApp.Application;
using CafeApp.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCafeInfrastructure(builder.Configuration);
builder.Services.AddCafeApplication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.MapGet("/health", () =>
{
    return Results.Ok(new { status = "Healthy" });
});
app.MapBookingEndpoints();

app.Run();
