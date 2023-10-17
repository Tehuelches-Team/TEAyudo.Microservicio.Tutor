using Application.DTO;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapPacienteDTOToPaciente
    {
        public Paciente Map(PacienteDTO PacienteDTO)
        {
            Paciente Pac = new Paciente
            {
                Nombre = PacienteDTO.Nombre,
                Apellido = PacienteDTO.Apellido,
                FechaNacimiento = PacienteDTO.FechaNacimiento,
                DiagnosticoTEA = PacienteDTO.DiagnosticoTEA,
                Sexo = PacienteDTO.Sexo,
                TutorId = PacienteDTO.TutorId
            };
            return Pac;
        }
    }
}
