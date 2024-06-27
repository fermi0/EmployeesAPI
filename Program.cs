using api.Data;
using api.Respository;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Endpoint discovery for swagger
builder.Services.AddSwaggerGen();

// Connect to SQL database using connection string
builder.Services.AddDbContext<StaffDB>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));
builder.Services.AddScoped<IStaffRepository, StaffRepository>(); // Adds interfaces

var app = builder.Build();

// Configure the HTTP request pipeline.
var env = app.Environment;
if (env.IsDevelopment() || env.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
