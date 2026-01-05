using Application;                 
using Application.UseCase;        
using Domain.Interfaces;           
using Infrastructure.Data;        
using Infrastructure.Repositories; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<InterfacesDiplomado, DiplomadoRepositorio>();
builder.Services.AddScoped<InterfacesDocente, DocenteRepositorio>();
builder.Services.AddScoped<InterfacesEstudiante, EstudianteRepositorio>();
builder.Services.AddScoped<InterfacesModulo, ModuloRepositorio>();
builder.Services.AddScoped<InterfacesInscripcion, InscripcionRepositorio>();
builder.Services.AddScoped<InterfacesNota, NotaRepositorio>();

builder.Services.AddScoped<CrearDiplomado>();
builder.Services.AddScoped<CrearDocente>();
builder.Services.AddScoped<CrearEstudiante>();
builder.Services.AddScoped<CrearModulo>();
builder.Services.AddScoped<CrearInscripcion>();
builder.Services.AddScoped<CrearNota>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();