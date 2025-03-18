using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<AboveZeroFilter>();

builder.Services.AddControllers()
    .AddXmlSerializerFormatters(); // enable XML output
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Registering the filter
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<AboveZeroFilter>();
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Update the AddDbContext method to include TrustServerCertificate=True
builder.Services.AddDbContext<ExperienceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") + ";TrustServerCertificate=True;"));

builder.Services.AddScoped<QueryService>();
builder.Services.AddScoped<GenericService<Provider>>();
builder.Services.AddScoped<GenericService<Experience>>();
builder.Services.AddScoped<GenericService<Guest>>();
builder.Services.AddScoped<GenericService<Discount>>();
builder.Services.AddScoped<GenericService<SharedExperience>>();
builder.Services.AddSingleton(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
