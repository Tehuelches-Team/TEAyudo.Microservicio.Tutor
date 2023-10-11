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
    }
}
