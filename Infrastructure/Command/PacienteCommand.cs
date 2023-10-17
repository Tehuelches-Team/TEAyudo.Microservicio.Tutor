using Application.Interface.Pacientes;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;

namespace Infrastructure.Command
{
    public class PacienteCommand : IPacienteCommand
    {
        private readonly TEAyudoContext Context;

        public PacienteCommand(TEAyudoContext Context)
        {
            this.Context = Context;
        }

        public async Task<Paciente?> PostPaciente(Paciente Paciente)
        {
            Tutor? Tutor = await Context.Tutores.FirstOrDefaultAsync(x => x.TutorId == Paciente.TutorId);
            if (Tutor != null)
            {
                Context.Pacientes.Add(Paciente);
                await Context.SaveChangesAsync();
                return Paciente;
            }
            return null;
        }

        public async Task<Paciente?> PutPaciente(Paciente Paciente)
        {
            Tutor? Tutor = await Context.Tutores.FirstOrDefaultAsync(f => f.TutorId == Paciente.TutorId);
            if (Tutor == null)
            {
                return null;
            }
            else
            {
                Paciente Pac = Context.Pacientes.FirstOrDefault(f => f.PacienteId == Paciente.PacienteId);
                Pac.Nombre = Paciente.Nombre;
                Pac.Apellido = Paciente.Apellido;
                Pac.FechaNacimiento = Paciente.FechaNacimiento;
                Pac.DiagnosticoTEA = Paciente.DiagnosticoTEA;
                Pac.Sexo = Paciente.Sexo;
                Pac.TutorId = Paciente.TutorId;
                await Context.SaveChangesAsync();
                return Paciente;
            }
        }

        public async Task DeletePaciente(int Id) 
        {
            Paciente Paciente = await Context.Pacientes.FirstOrDefaultAsync(f => f.PacienteId == Id);
            Context.Pacientes.Remove(Paciente);
            await Context.SaveChangesAsync();
        }
    }
}
