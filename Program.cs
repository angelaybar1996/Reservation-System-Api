using Microsoft.Data.SqlClient;
using reservas_api.Contracts;
using reservas_api.Repositories;
using reservas_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAerolineaRepository, AerolineaRepository>();
builder.Services.AddScoped<IAerolineaService, AerolineaService>();
builder.Services.AddScoped<IVueloRepository, VueloRepository>();
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
