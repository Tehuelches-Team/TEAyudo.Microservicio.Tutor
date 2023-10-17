using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;

namespace Infrastructure.Command
{
    public class TutorCommand : ITutorCommand
    {
        private readonly TEAyudoContext Context;

        public TutorCommand(TEAyudoContext Context)
        {
            this.Context = Context;
        }


        public async Task<bool> AddTutor(Tutor Tutor)
        {
            await Context.Tutores.AddAsync(Tutor);
            await Context.SaveChangesAsync();
            return true;
        }



        public async Task<Tutor?> PutTutor(int Id, TutorDTO TutorDTO)
        {
            Tutor? Tutor = await Context.Tutores.Include(p => p.Pacientes).FirstOrDefaultAsync(f => f.TutorId == Id);
            if (Tutor != null)
            {
                Tutor.UsuarioId = TutorDTO.UsuarioId;
                Tutor.CertUniDisc = TutorDTO.CertUniDisc;
                Context.Tutores.Update(Tutor);
                Context.SaveChanges();
                return Tutor;
            }
            return null;
        }



        public async Task<Tutor?> DeleteTutor(int Id)
        {
            Tutor? Tutor = await Context.Tutores.Include(p => p.Pacientes).FirstOrDefaultAsync(f => f.TutorId == Id);
            if (Tutor != null)
            {
                Context.Tutores.Remove(Tutor);
                await Context.SaveChangesAsync();
                return Tutor;
            }
            return null;
        }


    }
}
