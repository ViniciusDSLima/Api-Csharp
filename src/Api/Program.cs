using System.Configuration;
using Api.ViewModels;
using AutoMapper;
using Domain.Models;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<ManagerContext>();
builder.Services.AddDbContext<ManagerContext>(options => options.UseMySql("ConnectionStrings:USER_MANAGER",
    new MySqlServerVersion(new Version(5, 7, 43))), ServiceLifetime.Transient);

var app = builder.Build();

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>();
    cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
});

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