using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Context.Tutores.AddAsync(Tutor);
            Context.SaveChanges();
            return true;
        }
    }
}
