using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2.Swagger;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters(); // enable XML output
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Registering the filter
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
    c.EnableAnnotations();
    c.ParameterFilter<AboveZeroParameterFilter>(); 
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
