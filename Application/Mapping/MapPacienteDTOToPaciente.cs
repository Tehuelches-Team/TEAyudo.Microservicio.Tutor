using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MapPacienteDTOToPaciente
    {
        public Paciente Map (PacienteDTO PacienteDTO) 
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
