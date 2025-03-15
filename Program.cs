using Aflevering_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database connection (SQL Server in this case)
builder.Services.AddDbContext<ExperienceDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// Register the services
builder.Services.AddScoped<QueryService>();
builder.Services.AddScoped(typeof(GenericService<>)); // Register GenericService<T> for all entities
builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<ProviderService>();
builder.Services.AddScoped<SharedExperienceService>();
builder.Services.AddScoped<DiscountService>();

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
