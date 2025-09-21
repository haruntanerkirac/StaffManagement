using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using StaffManagement.Application;
using StaffManagement.Infrastructure;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddOpenApi();

builder.Services.AddRateLimiter(x=> 
x.AddFixedWindowLimiter("fixed", cfg =>
{
    cfg.QueueLimit = 100;
    cfg.Window = TimeSpan.FromSeconds(1);
    cfg.PermitLimit = 100;
    cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}));

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseCors(x => x.AllowAnyHeader().AllowCredentials().AllowAnyMethod().SetIsOriginAllowed(t => true));

app.MapControllers().RequireRateLimiting("fixed");

app.Run();
