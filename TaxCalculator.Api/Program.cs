using Microsoft.EntityFrameworkCore;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Repositories;
using TaxCalculator.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<TaxCalculatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxCalculatorConnection"))
);

builder.Services.AddScoped<ITaxCalculatorLogRepository, TaxCalculatorLogRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
