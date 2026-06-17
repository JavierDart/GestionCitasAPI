using GestionCitasAPI.Application.Interfaces.Artistas;
using GestionCitasAPI.Application.Interfaces.CatTatuajes;
using GestionCitasAPI.Application.Interfaces.Citas;
using GestionCitasAPI.Application.Interfaces.Clientes;
using GestionCitasAPI.Application.Interfaces.Pagos;
using GestionCitasAPI.Application.Interfaces.Tatuajes;
using GestionCitasAPI.Application.Services;
using GestionCitasAPI.Infrastructure.Data;
using GestionCitasAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IArtistasService, ArtistasService>();
builder.Services.AddScoped<IArtistasRepository, ArtistasRepository>();
builder.Services.AddScoped<ITatuajesRepository, TatuajesRepository>();
builder.Services.AddScoped<ITatuajesService, TatuajesService>();
builder.Services.AddScoped<ICitasService, CitasService>();
builder.Services.AddScoped<ICitasRepository, CitasRepository>();
builder.Services.AddScoped<IPagosRepository, PagosRepository>();
builder.Services.AddScoped<IPagosService, PagosService>();
builder.Services.AddScoped<ICatTatuajesService, CatTatuajesService>();
builder.Services.AddScoped<ICatTatuajesRepository, CatTatuajesRepository>();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
