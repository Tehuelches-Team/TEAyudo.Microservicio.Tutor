using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MapPacienteToPacienteResponse
    {
        public PacienteResponse Map (Paciente Paciente) 
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
