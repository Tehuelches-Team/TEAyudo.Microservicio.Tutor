using Domain.Entities;

namespace Application.Interface.Pacientes
{
    public interface IPacienteCommand
    {
        Task<Paciente?> PostPaciente(Paciente Paciente);
        Task<Paciente?> PutPaciente(Paciente Paciente);
        Task DeletePaciente(int Id);
    }
}
