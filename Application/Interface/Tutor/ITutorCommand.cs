using Application.DTO;
using Domain.Entities;

namespace Application.Interface
{
    public interface ITutorCommand
    {
        Task<bool> AddTutor(Tutor Tutor);
        Task<Tutor?> PutTutor(int Id, TutorDTO TutorDTO);
        Task<Tutor?> DeleteTutor(int Id);
    }
}
