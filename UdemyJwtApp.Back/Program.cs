using Microsoft.EntityFrameworkCore;
using UdemyJwtApp.Back.Core.Application.Interfaces;
using UdemyJwtApp.Back.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JwtContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
