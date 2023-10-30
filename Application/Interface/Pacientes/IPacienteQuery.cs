using Domain.Entities;

namespace Application.Interface.Pacientes
{
    public interface IPacienteQuery
    {
        Task<List<Paciente>> GetPacientes();
        Task<Paciente?> GetPacienteById(int Id);
    }
}
