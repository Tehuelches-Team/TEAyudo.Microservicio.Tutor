using Application.DTO;
using Application.Interface;
using Application.Model.Response;
using Microsoft.AspNetCore.Mvc;


namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService TutorService;

        public TutorController(ITutorService TutorService)
        {
            this.TutorService = TutorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTutor()
        {
            List<TutorResponse> ListaTutorResponse = await TutorService.GetAllTutor();
            if (ListaTutorResponse.Count == 0)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "La lista esta vacia."
                };
                return Ok(ObjetoAnonimo);
            }
            return Ok(ListaTutorResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetTutorById(int Id)
        {
            TutorResponse? Tutor = await TutorService.GetTutorById(Id);
            if (Tutor == null)
            {
                var ObejetoAnonimo = new
                {
                    Mensaje = "No se encontro el tutor."
                };
                return NotFound(ObejetoAnonimo);
            }
            return Ok(Tutor);
        }

        [HttpPost]
        public async Task<ActionResult> PostTutor(TutorDTO TutorDTO)
        {
            bool Resultado = await TutorService.AddTutor(TutorDTO);
            if (Resultado)
            {
                return new JsonResult("Tutor aniadido exitosamente") { StatusCode = 201 };
            }
            else
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha podido crear el tutor."
                };
                return BadRequest(ObjetoAnonimo);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutTutor(int Id, TutorDTO TutorDTO)
        {
            TutorResponse? TutorResponse = await TutorService.PutTutor(Id, TutorDTO);
            if (TutorResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el tutor a actualizar."
                };
                return new JsonResult(ObjetoAnonimo) { StatusCode = 404 };
            }
            return new JsonResult(TutorResponse) { StatusCode = 201 };
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTutor(int Id)
        {
            TutorResponse? TutorResponse = await TutorService.DeleteTutor(Id);
            if (TutorResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el tutor a eiminar."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(TutorResponse);
        }

    }
}
