using Application.Model.Response;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapPacientesToPacientesResponse
    {
        public List<PacienteResponse> Map(List<Paciente> ListaPaciente)
        {
            List<PacienteResponse> ListaPacienteResponse = new List<PacienteResponse>();
            MapPacienteToPacienteResponse Mapp = new MapPacienteToPacienteResponse();
            foreach (Paciente Pac in ListaPaciente)
            {
                PacienteResponse PacResponse = Mapp.Map(Pac);
                ListaPacienteResponse.Add(PacResponse);
            }
            return ListaPacienteResponse;
        }
    }
}
