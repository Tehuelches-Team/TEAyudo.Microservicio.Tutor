using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;
using TEAyudo_Tutores.Application.DTO;


namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public TutorController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDTO>> GetTutorById(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            // Mapea el tutor a TutorDTO
            var tutorDTO = MapTutorToTutorDTO(tutor);

            return tutorDTO;
        }

        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(TutorDTO tutorDTO)
        {
            var tutor = new Tutor
            {
                TutorId = tutorDTO.TutorId,
                UsuarioId = tutorDTO.UsuarioId,
                CertUniDisc = tutorDTO.CertUniDisc
            };

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.TutorId }, tutor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, TutorDTO tutorDTO) 
        {
            if (id != tutorDTO.TutorId)
            {
                return BadRequest();
            }

            var tutor = new Tutor
            {
                TutorId = tutorDTO.TutorId,
                UsuarioId = tutorDTO.UsuarioId,
                CertUniDisc = tutorDTO.CertUniDisc
                
            };

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TutorExists(int id)
        {
            return _context.Tutores.Any(e => e.TutorId == id);
        }

        private TutorDTO MapTutorToTutorDTO(Tutor tutor)
        {
            if (tutor == null)
            {
                return null;
            }

            var tutorDTO = new TutorDTO
            {
                TutorId = tutor.TutorId,
                UsuarioId = tutor.UsuarioId,
                CertUniDisc = tutor.CertUniDisc
            };

            return tutorDTO;
        }

    }
}
