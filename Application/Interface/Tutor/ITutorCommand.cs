using Application.DTO;
using Application.Model.DTO;
using Domain.Entities;

namespace Application.Interface
{
    public interface ITutorCommand
    {
        Task<bool> AddTutor(Tutor Tutor, UsuarioDTO UsuarioDTO);
        Task<Tutor?> PutTutor(int Id, TutorDTO TutorDTO);
        Task<Tutor?> DeleteTutor(int Id);
    }
}
