using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;

namespace Infrastructure.Query
{
    public class TutorQuery : ITutorQuery
    {
        private readonly TEAyudoContext Context;

        public TutorQuery(TEAyudoContext Context)
        {
            this.Context = Context;
        }



        public async Task<Tutor?> GetTutorById(int Id)
        {
            Tutor? Tutor = await Context.Tutores.Include(f => f.Pacientes).FirstOrDefaultAsync(t => t.TutorId == Id);
            return Tutor;
        }


        public async Task<List<Tutor>> GetAllTutor()
        {
            List<Tutor> ListaTutor = await Context.Tutores.Include(f => f.Pacientes).ToListAsync();
            return ListaTutor;
        }
    }
}
