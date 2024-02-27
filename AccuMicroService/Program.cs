using AccuMicroService;
using AccuMicroService.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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

builder.Services.AddDbContext<ApplicationDBContext>(o =>
{
    o.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IAccuWeatherApiService, AccuWeatherApiService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IAutomapperConfig, AutomapperConfig>();

//builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddTransient(typeof(IApplicationDBContext), typeof(ApplicationDBContext));

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "API-project", Version = "v1" });
    //option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Description = "Bearer Authentication with JWT Token",
    //    Type = SecuritySchemeType.Http
    //});
    //option.AddSecurityRequirement(new OpenApiSecurityRequirement {
    //    {
    //        new OpenApiSecurityScheme {
    //            Reference = new OpenApiReference {
    //                Id = "Bearer",
    //                    Type = ReferenceType.SecurityScheme
    //            }
    //        },
    //        new List < string > ()
    //    }
    //});
});

//builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey
//        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//});
//builder.Services.AddAuthorization();
//builder.Services.AddIdentity<User, Role>()
//    .AddEntityFrameworkStores<GardenCalendaryContext>()
//    .AddDefaultTokenProviders();

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
    //else if (ex?.Error is InvalidTokenException)
    //    context.Response.StatusCode = 400;
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
