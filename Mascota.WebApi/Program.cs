using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using DinkToPdf;
using DinkToPdf.Contracts;
using Mascota;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.CustomSchemaIds(type => type.ToString()); });
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddCors();
builder.Services.AddHttpClient();  // <-- Añadido
builder.Services.AddLogging();  // <-- Añadido

var app = builder.Build();
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
AppSettingHelper.AppSettingsConfigure(app.Services.GetRequiredService<IConfiguration>());

// Configure the HTTP request pipeline.

app.UseCors(options => {
    options.WithOrigins(config.GetSection("Parameters:OriginsHost").Value);
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
