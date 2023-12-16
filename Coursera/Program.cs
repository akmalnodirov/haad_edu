using Coursera;
using Coursera.Extensions;
using Coursera.Middleware;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//---------------------------------------------------------------------------------
//1. Adding authentication
//There is an internal service in .NET for authentication
//To use it we need to add it using AddAuthentication extension method
//This method has 3 different overloads:

//public static AuthenticationBuilder AddAuthentication(this IServiceCollection services)
//public static AuthenticationBuilder AddAuthentication(this IServiceCollection services, string defaultScheme) - add default schema
//public static AuthenticationBuilder AddAuthentication(this IServiceCollection services, Action<AuthenticationOptions> configureOptions) - add default schema and options

//After that we have to choose authentication schema
//There are two more popular schemas: Bearer and Cookies
//We can use of them use like:
//builder.Services.AddAuthentication("Cookies").AddCookie() or
//builder.Services.AddAuthentication("Bearer").AddJwtBearer()
//For using JWT schema, it must be installed from NUGET (Microsoft.AspNetCore.Authentication.JwtBearer)
//If we don't default scheme, we will get an error

//builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

//2. Adding authorization
//Authorization defines which resources user has a permission
//It also has two different overloads
//public static IServiceCollection AddAuthorization(this IServiceCollection services)
//public static IServiceCollection AddAuthorization(this IServiceCollection services, Action<AuthorizationOptions> configure)

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyForMicrosoft", policy =>
    {
        policy.RequireClaim("company", "Microsoft");
    });

    options.AddPolicy("OnlyForHaad", policy =>
    {
        policy.RequireClaim("company", "LearningCenter");
    });
});

//-----------------------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{}
                }
            });
});

var app = builder.Build();

//-------------------------------------------------------------

//After add services, authentication middleware added like this:
app.UseAuthentication();

//Adding authorization middleware
app.UseAuthorization();

//Adding the above configurations we have finished basic authentication and authorization
//But we still can access any resources
//Because we have not specify which resources should use authentication and authorization
//For that we have to use [Authorize] attribute in the controllers, actions or methods

//--------------------------------------------------------------


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();


app.MapControllers();

app.Run();
