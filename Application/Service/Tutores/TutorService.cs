using Application.DTO;
using Application.Interface;
using Application.Mapping;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Service.Tutores
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






        public async Task<int> AddTutor(TutorDTO TutorDTO)
        {
            Tutor Tutor = new Tutor
            {
                UsuarioId = TutorDTO.UsuarioId,
                Pacientes = new List<Paciente>(),
            };
            return await TutorCommand.AddTutor(Tutor);
        }







        public async Task<FullUsuarioResponse?> PutTutor(int Id, FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {
            Tutor? Tutor = await TutorQuery.GetTutorById(Id);
            if (Tutor == null)
            {
                return null;
            }
            MapFullToUsuarioDTO Mapping = new MapFullToUsuarioDTO();

            UsuarioDTO UsuarioDTO = Mapping.Map(FullUsuarioTutorDTO);
            UsuarioResponse Usuario = await TutorCommand.PutUsuario(Tutor.UsuarioId, UsuarioDTO);
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
            FullUsuarioResponse UsuarioFinal = FiltrarUsuariosTutores.Filtrar(Tutor, Usuario);
            return UsuarioFinal;
        }


        public async Task<List<FullUsuarioResponse?>> GetAllTutor()
        {
            List<Tutor>? ListaTutor = await TutorQuery.GetAllTutores();
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
