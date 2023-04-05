using clinica_bravo_backend.Controllers;
using clinica_bravo_backend.Filters;
using clinica_bravo_backend.Repositories;
using clinica_bravo_backend.Controllers;
using clinica_bravo_backend.Filters;
using clinica_bravo_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using clinica_bravo_backend.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton(provider =>
    new MapperConfiguration(config => {
        var geometryFactory = provider.GetRequiredService<GeometryFactory>();
        config.AddProfile(new AutoMapperProfiles(geometryFactory));
    }).CreateMapper());

builder.Services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddResponseCaching();
// builder.Services.AddTransient LifeTime short for any request
// builder.Services.AddScoped LifeTime medium for any request inside my http context
// builder.Services.AddSingleton LifeTime long for all time app

builder.Services.AddScoped<IRepository, RepositoryInMemory>(); 
builder.Services.AddTransient<MyActionFilter>();
builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(ExceptionFilter));
});

builder.Services.AddCors(options => {
    var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var frontend_url = MyConfig.GetValue<string>("frontend_url");
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
