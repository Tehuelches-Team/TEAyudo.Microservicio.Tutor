using Application.Interface;
using Application.Interface.Paciente;
using Application.Service;
using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;

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

//builder.Services.AddTransient<IPacienteService, PacienteService>();
//builder.Services.AddTransient<IPacienteCommand, PacienteCommand>();
//builder.Services.AddTransient<IPacienteQuery, PacienteQuery>();




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
