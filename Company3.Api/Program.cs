using Company3.Api.Infrastructure;
using Company3.Api.Infrastructure.FilterAttributes;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ClientCredentialsAuthActionFilterAttribute>();

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();
    options.OutputFormatters.Add(new XmlSerializerOutputFormatterNamespace());
}).AddXmlSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();