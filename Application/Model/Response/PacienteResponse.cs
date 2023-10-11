namespace Application.Model.Response
{
    public class PacienteResponse
    {
        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DiagnosticoTEA { get; set; }
        public string Sexo { get; set; }
        public int TutorId { get; set; }
    }
}
