using APBDKolokwium.Interfaces;
using APBDKolokwium.Models;
using APBDKolokwium.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<SubscriptionManagementDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    })
    .AddScoped<ISubscriptionManagementRepository, SubscriptionManagementRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
