using clinica_bravo_backend.Filters;
using clinica_bravo_backend.Repositories; 
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using AutoMapper; 
using Microsoft.EntityFrameworkCore; 
using NetTopologySuite;
using NetTopologySuite.Geometries;
using clinica_bravo_backend.Utils;
using clinica_bravo_backend;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text; 
 
//var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 
var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton(provider =>
    new MapperConfiguration(config => {
        var geometryFactory = provider.GetRequiredService<GeometryFactory>();
        config.AddProfile(new AutoMapperProfiles(geometryFactory));
    }).CreateMapper());

builder.Services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext> ()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options
    => options.TokenValidationParameters = new TokenValidationParameters { 
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes((string)builder.Configuration.GetValue(typeof(string), "keyjwt")) 
            ),
            ClockSkew = TimeSpan.Zero
       }
    );

builder.Services.AddAuthorization(opciones =>
{
    opciones.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", "admin"));
});

builder.Services.AddResponseCaching();
// builder.Services.AddTransient LifeTime short for any request
// builder.Services.AddScoped LifeTime medium for any request inside my http context
// builder.Services.AddSingleton LifeTime long for all time app

builder.Services.AddScoped<IRepository, RepositoryInMemory>();
builder.Services.AddTransient<IStorageFiles, AzureStorage>();
builder.Services.AddTransient<MyActionFilter>();
builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(ExceptionFilter));
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite())); 

builder.Services.AddCors(options => {
    string frontend_url = (string)builder.Configuration.GetValue(typeof(string), "frontend_url");
    options.AddDefaultPolicy(_builder => {
        _builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Map("/map1", (app) => {
    app.Run(async context => {
        await context.Response.WriteAsync("I'm intercepting the pipeline");
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
