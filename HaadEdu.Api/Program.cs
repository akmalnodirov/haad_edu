using HaadEdu.Api;
using HaadEdu.Api.Configurations;
using HaadEdu.Api.Infrastructure;
using HaadEdu.Application.Repositories;
using HaadEdu.Application.Result;
using HaadEdu.Application.Services;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();
builder.Services.ConfigureJWTService();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var response = new Result<object>(ErrorMessages.BadRequest);
        return new ModelValidationError(response);
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureLanguage();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseLanguageConfiguration();

app.UseSwaggerConfiguration();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
