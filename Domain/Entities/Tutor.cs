namespace Domain.Entities;
public class Tutor
{
    public int TutorId { get; set; }
    public int UsuarioId { get; set; }
    public List<Paciente> Pacientes { get; set; }
}
