using Application.DTO;
using Application.Interface;
using Application.Mapping;
using Application.Model.DTO;
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

        public async Task<bool> AddTutor(FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {

            Tutor Tutor = new Tutor
            {
                UsuarioId = FullUsuarioTutorDTO.UsuarioId,
                Pacientes = new List<Paciente>(),
                CertUniDisc = FullUsuarioTutorDTO.CertUniDisc
            };
            UsuarioDTO UsuarioDTO = new UsuarioDTO
            {
                Nombre = FullUsuarioTutorDTO.Nombre,
                Apellido = FullUsuarioTutorDTO.Apellido,
                CorreoElectronico = FullUsuarioTutorDTO.CorreoElectronico,
                Contrasena = FullUsuarioTutorDTO.Contrasena,
                FotoPerfil = FullUsuarioTutorDTO.FotoPerfil,
                Domicilio = FullUsuarioTutorDTO.Domicilio,
                FechaNacimiento = FullUsuarioTutorDTO.FechaNacimiento
            };

            return await TutorCommand.AddTutor(Tutor, UsuarioDTO);
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
