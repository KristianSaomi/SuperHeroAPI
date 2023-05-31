global using SuperHeroAPI.Models;
global using SuperHeroAPI.Data;
using SuperHeroAPI.Services.SuperHeroService;
using AutoMapper;
using SuperHeroAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register a new service with the dependency injection
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
// Register DataContext
builder.Services.AddDbContext<DataContext>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

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
