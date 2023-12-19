using Application.DTO;
using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface
{
    public interface ITutorService
    {
        Task<List<FullUsuarioResponse>>? GetAllTutor();
        Task<FullUsuarioResponse?> GetTutorById(int Id);
        Task<int> AddTutor(TutorDTO TutorDTO);
        Task<FullUsuarioResponse?> PutTutor(int Id, FullUsuarioTutorDTO FullUsuarioTutorDTO);
        Task<FullUsuarioResponse?> DeleteTutor(int Id);
        Task<int?> GetTutorIdbyUsuarioId(int UsuarioId);
    }
}
