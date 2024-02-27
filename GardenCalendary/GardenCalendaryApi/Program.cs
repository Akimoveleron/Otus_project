using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Services;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var configurationBuilder = new ConfigurationBuilder();
var config = configurationBuilder.AddJsonFile("appsettings.json").Build();
var connectionString = config[$"ConnectionStrings:PostgreSQL"];


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<GardenCalendaryContext>(o =>
{
    o.UseNpgsql(connectionString);
});


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAutomapperConfig, AutomapperConfig>();
builder.Services.AddScoped<IGardenService, GardenService>();

builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddTransient(typeof(IGardenCalendaryContext), typeof(GardenCalendaryContext));

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "API-project", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});

builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<GardenCalendaryContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(builder => builder.AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var ex = context.Features.Get<IExceptionHandlerPathFeature>();
    if (ex?.Error is NullReferenceException)
        context.Response.StatusCode = 404;
    else if (ex?.Error is InvalidTokenException)
        context.Response.StatusCode = 400;
    else
        context.Response.StatusCode = 500;

    context.Response.ContentType = "application/json";

    await context.Response.WriteAsync(JsonConvert.SerializeObject(ex?.Error.Message));
}));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();




static void ReturnAllLabelsInConsole(object entity)
{
    IEnumerable<FieldInfo> fields = entity.GetType().GetTypeInfo().DeclaredFields;

    foreach (var field in fields.Where(x => !x.IsStatic))
    {
        Console.WriteLine("{0}  =  {1}", field.Name, (entity != null) ? field.GetValue(entity) : string.Empty);
    }
}