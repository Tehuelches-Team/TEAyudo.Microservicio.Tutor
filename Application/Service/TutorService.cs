using Application.DTO;
using Application.Interface;
using Application.Mapping;
using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TutorService : ITutorService
    {
        private readonly ITutorQuery TutorQuery;
        private readonly ITutorCommand TutorCommand;

        public TutorService (ITutorQuery TutorQuery, ITutorCommand TutorCommand)
        {
            this.TutorQuery = TutorQuery;
            this.TutorCommand = TutorCommand;
        }

        public async Task<TutorResponse?> GetTutorById(int Id) 
        {
            Tutor? Tutor = await TutorQuery.GetTutorById(Id);
            TutorResponse? TutorResponse;
            if (Tutor == null) 
            {
                TutorResponse = null;
            }
            else
            {
                TutorResponse = new TutorResponse
                {
                    UsuarioId = Tutor.UsuarioId,
                    PacientesResPonse = MapPacientesToPacientesResponse.Map(Tutor.Pacientes),
                    CertUniDisc = Tutor.CertUniDisc,
                };
            }
            return TutorResponse;
        }
    
        public async Task<bool> AddTutor(TutorDTO TutorDTO) 
        {
            Tutor Tutor = new Tutor
            {
                UsuarioId = TutorDTO.UsuarioId,
                Pacientes = new List<Paciente>(),
                CertUniDisc = TutorDTO.CertUniDisc
            };
            return await TutorCommand.AddTutor(Tutor);
        }
    }
}
