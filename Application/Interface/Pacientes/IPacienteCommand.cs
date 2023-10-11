using Application.DTO;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Interface.Pacientes
{
    public interface IPacienteCommand
    {
        Task<Paciente?> PostPaciente(Paciente Paciente);
    }
}
