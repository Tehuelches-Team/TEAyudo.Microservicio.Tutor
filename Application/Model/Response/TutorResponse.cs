using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class TutorResponse
    {
        public int UsuarioId { get; set; }
        public List<PacienteResponse> PacientesResPonse { get; set; }
        public string CertUniDisc { get; set; }
    }
}
