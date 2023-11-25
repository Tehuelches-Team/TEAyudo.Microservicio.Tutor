using Application.DTO;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Interface
{
    public interface ITutorCommand
    {
        Task<int> AddTutor(Tutor Tutor);
        Task<Tutor?> PutTutor(int Id, TutorDTO TutorDTO);
        Task<UsuarioResponse?> PutUsuario(int Id, UsuarioDTO UsuarioDTO);
        Task<Tutor?> DeleteTutor(int Id);
        Task<UsuarioResponse?> DeleteUsuario(int Id);
    }
}
