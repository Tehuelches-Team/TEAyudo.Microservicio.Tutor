using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using TEAyudo_Tutores;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interface;
using Application.Model.Response;
using Application.Interface.Pacientes;

namespace TEAyudo_Tutores.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService PacienteService;

        public PacienteController(IPacienteService PacienteService)
        {
            this.PacienteService = PacienteService;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult> GetPacientes()
        {
            List<PacienteResponse> ListaResponse = await PacienteService.GetPacientes();
            if (ListaResponse.Count == 0)
            {
                return NoContent(); //codigo 204 realizada correctamente pero sin contenido devuelto
            }
            return Ok(ListaResponse);
        }


        // GET: api/pacientes/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetPaciente(int Id)
        {
            PacienteResponse? PacienteResponse = await PacienteService.GetPacienteById(Id);
            if (PacienteResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se encontro el paciente con el ID indicado."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(PacienteResponse);
        }


        // POST: api/pacientes
        [HttpPost]
        public async Task<ActionResult> PostPaciente(PacienteDTO PacienteDTO)
        {
            PacienteResponse? PacienteResponse = await PacienteService.PostPaciente(PacienteDTO);
            if (PacienteResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha podido crear el paciente por que no se encontro un tutor con el ID = " + PacienteDTO.TutorId
                };
                return Conflict(ObjetoAnonimo);
            }
            return new JsonResult(PacienteResponse) { StatusCode = 201 };
        }






        //        // PUT: api/pacientes/{id}
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutPaciente(int id, PacienteDTO pacienteDTO)
        //        {
        //            // Implementa lógica para actualizar un paciente por su ID a partir de PacienteDTO
        //            if (id != pacienteDTO.PacienteId)
        //            {
        //                return BadRequest();
        //            }

        //            var paciente = MapPacienteDTOToPaciente(pacienteDTO);

        //            _context.Entry(paciente).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!PacienteExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // DELETE: api/pacientes/{id}
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeletePaciente(int id)
        //        {
        //            // Implementa lógica para eliminar un paciente por su ID
        //            var paciente = await _context.Pacientes.FindAsync(id);
        //            if (paciente == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Pacientes.Remove(paciente);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool PacienteExists(int id)
        //        {
        //            // Implementa lógica para verificar si un paciente existe por su ID
        //            return _context.Pacientes.Any(e => e.PacienteId == id);
        //        }

        //        private PacienteDTO MapPacienteToPacienteDTO(Paciente paciente)
        //        {
        //            return new PacienteDTO
        //            {
        //                PacienteId = paciente.PacienteId,
        //                Nombre = paciente.Nombre,
        //                Apellido = paciente.Apellido,
        //                FechaNacimiento = paciente.FechaNacimiento,
        //                DiagnosticoTEA = paciente.DiagnosticoTEA,
        //                Sexo = paciente.Sexo,
        //                TutorId = paciente.TutorId
        //            };
        //        }


        //        private Paciente MapPacienteDTOToPaciente(PacienteDTO pacienteDTO)
        //        {
        //            return new Paciente
        //            {
        //                PacienteId = pacienteDTO.PacienteId,
        //                Nombre = pacienteDTO.Nombre,
        //                Apellido = pacienteDTO.Apellido,
        //                FechaNacimiento = pacienteDTO.FechaNacimiento,
        //                DiagnosticoTEA = pacienteDTO.DiagnosticoTEA,
        //                Sexo = pacienteDTO.Sexo,
        //                TutorId = pacienteDTO.TutorId
        //            };
        //        }
        //    }
    }
}
