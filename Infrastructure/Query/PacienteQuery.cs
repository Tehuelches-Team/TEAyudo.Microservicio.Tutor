using Application.Interface.Pacientes;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;

namespace Infrastructure.Query
{
    public class PacienteQuery : IPacienteQuery
    {
        private readonly TEAyudoContext Context;

        public PacienteQuery(TEAyudoContext Context)
        {
            this.Context = Context;
        }


        public async Task<List<Paciente>> GetPacientes()
        {
            return await Context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> GetPacienteById(int Id)
        {
            return await Context.Pacientes.FirstOrDefaultAsync(f => f.PacienteId == Id);
        }

    }
}
