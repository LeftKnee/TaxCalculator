using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
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

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7102", "http://localhost:7102")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
