using Application.Interface;
using Application.Interface.Pacientes;
using Application.Service;
using Application.Service.Tutores;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TEAyudoContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=TEAyudo_Tutores;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");

});

builder.Services.AddTransient<ITutorService, TutorService>();
builder.Services.AddTransient<ITutorCommand, TutorCommand>();
builder.Services.AddTransient<ITutorQuery, TutorQuery>();

builder.Services.AddTransient<IPacienteService, PacienteService>();
builder.Services.AddTransient<IPacienteCommand, PacienteCommand>();
builder.Services.AddTransient<IPacienteQuery, PacienteQuery>();

builder.Services.AddTransient<IFiltrarUsuariosTutores, FiltrarUsuariosTutores>();

builder.Services.AddCors(x => x.AddDefaultPolicy(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
