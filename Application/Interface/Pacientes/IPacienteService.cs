using Application.DTO;
using Application.Model.Response;

namespace Application.Interface.Pacientes
{
    public interface IPacienteService
    {
        Task<List<PacienteResponse>> GetPacientes();
        Task<PacienteResponse?> GetPacienteById(int Id);
        Task<PacienteResponse?> PostPaciente(PacienteDTO PacienteDTO);
        Task<PacienteResponse?> PutPaciente(int Id, PacienteDTO PacienteDTO);
        Task<bool> DeletePaciente(int Id);
    }
}
