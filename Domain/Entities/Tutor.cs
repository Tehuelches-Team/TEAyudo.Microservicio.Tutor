using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Tutor
{
    //[Key]
    //la data annotation key no va porque ya lo especifico en el context
    

    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //esa linea no va porque es autoincremental por defecto


    public int TutorId { get; set; }
    public int UsuarioId { get; set; }
    public List<Paciente> Pacientes { get; set; }
    public string CertUniDisc { get; set; }
}
