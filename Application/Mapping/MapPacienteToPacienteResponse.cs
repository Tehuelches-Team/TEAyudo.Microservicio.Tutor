using Application.Model.Response;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapPacienteToPacienteResponse
    {
        public PacienteResponse Map(Paciente Paciente)
        {
            return new PacienteResponse
            {
                PacienteId = Paciente.PacienteId,
                Nombre = Paciente.Nombre,
                Apellido = Paciente.Apellido,
                FechaNacimiento = Paciente.FechaNacimiento,
                DiagnosticoTEA = Paciente.DiagnosticoTEA,
                Sexo = Paciente.DiagnosticoTEA,
                TutorId = Paciente.TutorId
            };
        }
    }
}
