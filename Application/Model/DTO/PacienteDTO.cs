namespace Application.DTO;

public class PacienteDTO
{
    public int TutorId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string DiagnosticoTEA { get; set; }
    public string Sexo { get; set; }
}