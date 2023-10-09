namespace Application.Model.Response
{
    public class TutorResponse
    {
        public int TutorId { get; set; }
        public int UsuarioId { get; set; }
        public List<PacienteResponse> PacientesResPonse { get; set; }
        public string CertUniDisc { get; set; }
    }
}
