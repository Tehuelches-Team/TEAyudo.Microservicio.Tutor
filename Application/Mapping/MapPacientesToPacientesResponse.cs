using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class MapPacientesToPacientesResponse
    {
        public static List<PacienteResponse> Map(List<Paciente> ListaPaciente)
        {
            List<PacienteResponse> ListaPacienteResponse = new List<PacienteResponse>();
            foreach (Paciente Pac in ListaPaciente) 
            {
                PacienteResponse PacResponse = new PacienteResponse
                {
                    Nombre = Pac.Nombre,
                    Apellido = Pac.Apellido,
                    FechaNacimiento = Pac.FechaNacimiento,
                    DiagnosticoTEA = Pac.DiagnosticoTEA,
                    Sexo = Pac.DiagnosticoTEA,
                    TutorId = Pac.TutorId
                };
                ListaPacienteResponse.Add(PacResponse);
            }
            return ListaPacienteResponse;
        } 
    }
}
