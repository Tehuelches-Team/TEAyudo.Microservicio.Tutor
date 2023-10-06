using Application.DTO;
using Application.Interface;
using Application.Model.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;


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
                return new JsonResult("Tutor aniadido exitosamente") { StatusCode = 201};
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTutor(int id, TutorDTO tutorDTO) 
        //{
        //    if (id != tutorDTO.TutorId)
        //    {
        //        return BadRequest();
        //    }

        //    var tutor = new Tutor
        //    {
        //        TutorId = tutorDTO.TutorId,
        //        UsuarioId = tutorDTO.UsuarioId,
        //        CertUniDisc = tutorDTO.CertUniDisc
                
        //    };

        //    _context.Entry(tutor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TutorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTutor(int id)
        //{
        //    var tutor = await _context.Tutores.FindAsync(id);
        //    if (tutor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tutores.Remove(tutor);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TutorExists(int id)
        //{
        //    return _context.Tutores.Any(e => e.TutorId == id);
        //}

        //private TutorDTO MapTutorToTutorDTO(Tutor tutor)
        //{
        //    if (tutor == null)
        //    {
        //        return null;
        //    }

        //    var tutorDTO = new TutorDTO
        //    {
        //        TutorId = tutor.TutorId,
        //        UsuarioId = tutor.UsuarioId,
        //        CertUniDisc = tutor.CertUniDisc
        //    };

        //    return tutorDTO;
        //}

    }
}
