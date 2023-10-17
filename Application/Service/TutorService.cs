using Application.DTO;
using Application.Interface;
using Application.Mapping;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Service
{
    public class TutorService : ITutorService
    {
        private readonly ITutorQuery TutorQuery;
        private readonly ITutorCommand TutorCommand;

        public TutorService(ITutorQuery TutorQuery, ITutorCommand TutorCommand)
        {
            this.TutorQuery = TutorQuery;
            this.TutorCommand = TutorCommand;
        }

        public async Task<TutorResponse?> GetTutorById(int Id)
        {
            Tutor? Tutor = await TutorQuery.GetTutorById(Id);
            TutorResponse? TutorResponse;
            MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            if (Tutor == null)
            {
                TutorResponse = null;
            }
            else
            {
                TutorResponse = new TutorResponse
                {
                    TutorId = Tutor.TutorId,
                    UsuarioId = Tutor.UsuarioId,
                    PacientesResPonse = Mapping.Map(Tutor.Pacientes),
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

        public async Task<TutorResponse?> PutTutor(int Id, TutorDTO TutorDTO)
        {
            Tutor? Tutor = await TutorCommand.PutTutor(Id, TutorDTO);
            MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            if (Tutor != null)
            {
                TutorResponse TutorResponse = new TutorResponse
                {
                    TutorId = Tutor.TutorId,
                    UsuarioId = Tutor.UsuarioId,
                    PacientesResPonse = Mapping.Map(Tutor.Pacientes),
                    CertUniDisc = Tutor.CertUniDisc,
                };
                return TutorResponse;
            }
            return null;
        }

        public async Task<TutorResponse?> DeleteTutor(int Id)
        {
            Tutor? Tutor = await TutorCommand.DeleteTutor(Id);
            MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            if (Tutor != null)
            {
                TutorResponse TutorResponse = new TutorResponse
                {
                    TutorId = Tutor.TutorId,
                    UsuarioId = Tutor.UsuarioId,
                    PacientesResPonse = Mapping.Map(Tutor.Pacientes),
                    CertUniDisc = Tutor.CertUniDisc,
                };
                return TutorResponse;
            }
            return null;
        }


        public async Task<List<TutorResponse>> GetAllTutor()
        {
            List<Tutor> ListaTutor = await TutorQuery.GetAllTutor();
            List<TutorResponse> ListaTutorResponse = new List<TutorResponse>();
            MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            TutorResponse TutorResponse;
            foreach (Tutor Tutor in ListaTutor)
            {
                TutorResponse = new TutorResponse
                {
                    TutorId = Tutor.TutorId,
                    UsuarioId = Tutor.UsuarioId,
                    PacientesResPonse = Mapping.Map(Tutor.Pacientes),
                    CertUniDisc = Tutor.CertUniDisc
                };
                ListaTutorResponse.Add(TutorResponse);
            }
            return ListaTutorResponse;
        }


    }
}
