using Application.DTO;
using Application.Interface.Pacientes;
using Application.Mapping;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteQuery PacienteQuery;
        private readonly IPacienteCommand PacienteCommand;

        public PacienteService(IPacienteQuery PacienteQuery, IPacienteCommand PacienteCommand)
        {
            this.PacienteQuery = PacienteQuery;
            this.PacienteCommand = PacienteCommand;
        }

        public async Task<List<PacienteResponse>> GetPacientes()
        {
            List<Paciente> ListaPaciente = await PacienteQuery.GetPacientes();
            MapPacientesToPacientesResponse Mapping = new MapPacientesToPacientesResponse();
            List<PacienteResponse> ListaResponse = Mapping.Map(ListaPaciente);
            return ListaResponse;
        }

        public async Task<PacienteResponse?> GetPacienteById(int Id)
        {
            Paciente? Paciente = await PacienteQuery.GetPacienteById(Id);
            MapPacienteToPacienteResponse Mapping = new MapPacienteToPacienteResponse();
            if (Paciente != null)
            {
                return Mapping.Map(Paciente);
            }
            return null;
        }

        public async Task<PacienteResponse?> PostPaciente(PacienteDTO PacienteDTO)
        {
            MapPacienteDTOToPaciente Mapping = new MapPacienteDTOToPaciente();
            Paciente Pac = Mapping.Map(PacienteDTO);
            Paciente? Paciente = await PacienteCommand.PostPaciente(Pac);
            if (Paciente != null)
            {
                MapPacienteToPacienteResponse Mapping2 = new MapPacienteToPacienteResponse();
                return Mapping2.Map(Paciente);
            }
            return null;
        }

        public async Task<PacienteResponse?> PutPaciente(int Id, PacienteDTO PacienteDTO)
        {
            MapPacienteDTOToPaciente Mapping = new MapPacienteDTOToPaciente();
            Paciente? Pac = Mapping.Map(PacienteDTO);
            Pac.PacienteId = Id;
            Paciente? Pac2 = await PacienteCommand.PutPaciente(Pac);
            if (Pac2 != null)
            {
                MapPacienteToPacienteResponse Mapping2 = new MapPacienteToPacienteResponse();
                PacienteResponse PacienteResponse = Mapping2.Map(Pac2);
                return PacienteResponse;
            }
            return null;
        }

        public async Task<bool> DeletePaciente(int Id)
        {
            await PacienteCommand.DeletePaciente(Id);
            return true;
        }

    }
}
