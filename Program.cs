using Hangfire;
using HangFireApp.Context;
using HangFireApp.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string connectionString= builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    builder.Services.AddHangfire(config =>
    {
        config.UseSqlServerStorage(connectionString);
    });
    builder.Services.AddHangfireServer();
    var app = builder.Build();

    app.UseHangfireDashboard();
    RecurringJob.AddOrUpdate("mail-job",() => 
    EmailService.SendEmail("example@example.com", "Hello!"),
    Cron.Hourly());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
