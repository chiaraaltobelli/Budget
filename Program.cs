/// Copyright (c) 2026 Chiara Altobelli

using Microsoft.EntityFrameworkCore;
using Budget.Server.Data;
using Budget.Server.Interfaces;
using Budget.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BudgetDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BudgetDb")));

builder.Services.AddSingleton<TimeService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
