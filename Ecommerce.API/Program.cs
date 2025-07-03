using Ecommerce.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Infrastructure Services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configure AutoMapper to scan all assemblies
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly(),
     typeof(Ecommerce.Infrastructure.Data.AppDBContext).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure wwwroot exists
var wwwrootPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot");
if (!Directory.Exists(wwwrootPath))
{
    Directory.CreateDirectory(wwwrootPath);
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Enable static files serving

app.UseAuthorization();
app.MapControllers();

app.Run();