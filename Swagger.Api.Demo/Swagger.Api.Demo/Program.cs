using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = configuration.GetSection("Swagger:Title").Value,
        Description = string.Concat(configuration.GetSection("Swagger:Description").Value, $"© Copyright {DateTime.Now.Year}. All rights reserved."),
        Version = configuration.GetSection("Swagger:Version").Value,
        Contact = new OpenApiContact
        {
            Name = configuration.GetSection("Swagger:Contact:Name").Value,
            Url = new Uri(configuration.GetSection("Swagger:Contact:Url").Value)
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(configuration.GetSection("Swagger:Url").Value, configuration.GetSection("Swagger:Name").Value);
        options.DocumentTitle = configuration.GetSection("Swagger:Name").Value;
        options.InjectStylesheet(configuration.GetSection("Swagger:Css").Value);
        options.DisplayRequestDuration();
        options.EnableFilter();
    });
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
