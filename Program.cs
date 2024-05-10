using Asp.Versioning;
using CityManager.WebAPI.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVersion = Asp.Versioning.ApiVersion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
        options.Filters.Add(new ConsumesAttribute("application/json"));
    })
      .AddXmlSerializerFormatters();
builder.Services.AddApiVersioning(
    config =>
    {
        config.ApiVersionReader = new UrlSegmentApiVersionReader();

        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
    }
    );
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });

//Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "API Cities", Version = "1.0" });
        options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "API Cities", Version = "2.0" });
    });
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
    });
app.UseAuthorization();
app.MapControllers();
// Enable detailed error information in the development environment
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.Run();

