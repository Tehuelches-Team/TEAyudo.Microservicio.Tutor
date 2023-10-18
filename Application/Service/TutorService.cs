using Application.DTO;
using Application.Interface;
using Application.Mapping;
using Application.Model.DTO;
using Application.Model.Response;
using Application.Service.Tutores;
using Domain.Entities;

namespace Application.Service
{
    public class TutorService : ITutorService
    {
        private readonly ITutorQuery TutorQuery;
        private readonly ITutorCommand TutorCommand;
        private readonly IFiltrarUsuariosTutores FiltrarUsuariosTutores;

        public TutorService(ITutorQuery TutorQuery, ITutorCommand TutorCommand, IFiltrarUsuariosTutores FiltrarUsuariosTutores)
        {
            this.TutorQuery = TutorQuery;
            this.TutorCommand = TutorCommand;
            this.FiltrarUsuariosTutores = FiltrarUsuariosTutores;
        }

        public async Task<FullUsuarioResponse?> GetTutorById(int Id)
        {
            Tutor? Tutor = await TutorQuery.GetTutorById(Id);
            if (Tutor == null)
            {
                return null;
            }
            UsuarioResponse Result = await TutorQuery.GetUsuarioById(Tutor.UsuarioId);
            FullUsuarioResponse UsuarioFinal = FiltrarUsuariosTutores.Filtrar(Tutor, Result);
            return UsuarioFinal;
        }

        public async Task<bool> AddTutor(FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {

            Tutor Tutor = new Tutor
            {
                Pacientes = new List<Paciente>(), //Ver como setear el UsuarioId
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

        public async Task<FullUsuarioResponse?> PutTutor(int Id, FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {
            Tutor? Tutor = await TutorQuery.GetTutorById(Id);
            if (Tutor == null)
            {
                return null;
            }
            //UsuarioDTO UsuarioDTO = Usar los mapping que estan al pedo ;
            UsuarioDTO UsuarioDTO = new UsuarioDTO
            {
                Nombre = FullUsuarioTutorDTO.Nombre,
                Apellido = FullUsuarioTutorDTO.Apellido,
                Contrasena = FullUsuarioTutorDTO.Contrasena,
                CorreoElectronico = FullUsuarioTutorDTO.CorreoElectronico,
                Domicilio = FullUsuarioTutorDTO.Domicilio,
                FechaNacimiento = FullUsuarioTutorDTO.FechaNacimiento,
                FotoPerfil = FullUsuarioTutorDTO.FotoPerfil,
            };
            UsuarioResponse Usuario = await TutorCommand.PutUsuario(Tutor.UsuarioId, UsuarioDTO);
            //Tutor = await TutorCommand.PutTutor(Id,TutorDTO);
            FullUsuarioResponse UsuarioFinal = FiltrarUsuariosTutores.Filtrar(Tutor, Usuario);
            return UsuarioFinal;
        }

        public async Task<FullUsuarioResponse?> DeleteTutor(int Id)
        {
            Tutor? Tutor = await TutorCommand.DeleteTutor(Id);
            if (Tutor == null)
            {
                return null;
            }

            UsuarioResponse Usuario = await TutorCommand.DeleteUsuario(Tutor.UsuarioId);
            //MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            //if (Tutor != null)
            //{
            //    TutorResponse TutorResponse = new TutorResponse
            //    {
            //        TutorId = Tutor.TutorId,
            //        UsuarioId = Tutor.UsuarioId,
            //        PacientesResPonse = Mapping.Map(Tutor.Pacientes),
            //    };
            //    return TutorResponse;
            //}
            //return null;
            FullUsuarioResponse UsuarioFinal = FiltrarUsuariosTutores.Filtrar(Tutor, Usuario);
            return UsuarioFinal;
        }


        public async Task<List<FullUsuarioResponse?>> GetAllTutor()
        {  
            List<Tutor> ListaTutor = await TutorQuery.GetAllTutores();
            if (ListaTutor.Count == 0)
            {
                return null;
            }
            List<UsuarioResponse> ListaUsuarioResponse = await TutorQuery.GetAllUsuarios();
            List<FullUsuarioResponse> FinalList = FiltrarUsuariosTutores.Filtrar(ListaTutor, ListaUsuarioResponse);
            return FinalList;
        }
    }
}
