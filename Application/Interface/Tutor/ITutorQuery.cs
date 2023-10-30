using Application.Model.Response;
using Domain.Entities;

namespace Application.Interface
{
    public interface ITutorQuery
    {
        Task<Tutor?> GetTutorById(int Id);
        Task<List<Tutor>> GetAllTutores();
        Task<List<UsuarioResponse>>? GetAllUsuarios();
        Task<UsuarioResponse?> GetUsuarioById(int Id);
    }
}
