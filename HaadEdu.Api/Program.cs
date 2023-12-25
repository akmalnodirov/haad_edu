using HaadEdu.Api;
using HaadEdu.Api.Configurations;
using HaadEdu.Application.Repositories;
using HaadEdu.Application.Services;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();
builder.Services.ConfigureJWTService();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRoleService, RoleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerConfiguration();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
