using Domain.Entities;

namespace Application.Interface
{
    public interface ITutorQuery
    {
        Task<Tutor?> GetTutorById(int Id);
        Task<List<Tutor>> GetAllTutor();
    }
}
