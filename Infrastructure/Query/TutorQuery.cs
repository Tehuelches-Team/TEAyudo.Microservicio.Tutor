using Application.Interface;
using Application.Model.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo_Tutores;

namespace Infrastructure.Query
{
    public class TutorQuery : ITutorQuery
    {
        private readonly TEAyudoContext Context;

        public TutorQuery (TEAyudoContext Context) 
        {
            this.Context = Context;
        }

        public async Task<Tutor?> GetTutorById(int Id) 
        {
            Tutor? Tutor = await Context.Tutores.Include(f => f.Pacientes).FirstOrDefaultAsync(t => t.TutorId == Id);
            return Tutor;
        }
    }
}
