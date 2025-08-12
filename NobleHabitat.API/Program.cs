using NobleHabitat.Infraestructure.DependencyInjection;
using NobleHabitat.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
