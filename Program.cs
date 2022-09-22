using Microsoft.EntityFrameworkCore;
using UnitOfWork.Core.IConfiguration;
using UnitOfWork.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicationDbContext>
(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);
//Adding UnitOfWork to DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkk>();

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
