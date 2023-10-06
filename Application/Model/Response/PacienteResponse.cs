using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class PacienteResponse
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DiagnosticoTEA { get; set; }
        public string Sexo { get; set; }
        public int TutorId { get; set; }
    }
}
