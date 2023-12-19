using Application.DTO;
using Application.Interface.Pacientes;
using Application.Model.Response;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetPacientes()
        {
            List<PacienteResponse> ListaResponse = await PacienteService.GetPacientes();
            if (ListaResponse.Count == 0)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se encontraron pacientes."
                };
                return NotFound(ObjetoAnonimo); 
            }
            return Ok(ListaResponse);
        }


        // GET: api/pacientes/{id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPaciente(int Id)
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
        public async Task<IActionResult> PostPaciente(PacienteDTO PacienteDTO)
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


        // PUT: api/pacientes/{id}
        [HttpPut("{Id}")]
        public async Task<ActionResult> PutPaciente(int Id, PacienteDTO PacienteDTO)
        {
            PacienteResponse? PacienteResponse = await PacienteService.GetPacienteById(Id);
            if (PacienteResponse != null)
            {
                PacienteResponse = await PacienteService.PutPaciente(Id, PacienteDTO);
                if (PacienteResponse != null)
                {
                    return new JsonResult(PacienteResponse) { StatusCode = 201 };
                }
                else
                {
                    var ObjetoAnonimo = new
                    {
                        Mensaje = "No se ha podido crear el paciente por que no se encontro un tutor con el ID " + PacienteDTO.TutorId
                    };
                    return Conflict(ObjetoAnonimo);
                }
            }
            var ObjetoAnonimo2 = new
            {
                Mensaje = "No se ha encontrado al usuario con el ID " + Id
            };
            return NotFound(ObjetoAnonimo2);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePaciente(int Id)
        {
            PacienteResponse? PacienteResponse = await PacienteService.GetPacienteById(Id);
            if (PacienteResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha podido encontrar el paciente con el ID " + Id
                };
                return NotFound(ObjetoAnonimo);
            }
            await PacienteService.DeletePaciente(Id);
            return Ok(PacienteResponse);
        }
    }
}
