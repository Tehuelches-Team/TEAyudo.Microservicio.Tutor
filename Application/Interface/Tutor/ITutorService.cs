using Application.DTO;
using Application.Model.DTO;
using Application.Model.Response;

namespace Application.Interface
{
    public interface ITutorService
    {
        Task<List<TutorResponse>> GetAllTutor();
        Task<TutorResponse?> GetTutorById(int Id);
        Task<bool> AddTutor(FullUsuarioTutorDTO FullUsuarioTutorDTO);
        Task<TutorResponse?> PutTutor(int Id, TutorDTO TutorDTO);
        Task<TutorResponse?> DeleteTutor(int Id);
    }
}
