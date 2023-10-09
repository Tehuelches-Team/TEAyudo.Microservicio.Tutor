//using System.Linq;
//using System.Threading.Tasks;
//using Domain.Entities;
//using TEAyudo_Tutores;
//using Application.DTO;

//namespace TEAyudo_Tutores.Controllers
//{
//    [Route("api/pacientes")]
//    [ApiController]
//    public class PacienteController : ControllerBase
//    {
//        private readonly TEAyudoContext _context;

//        public PacienteController(TEAyudoContext context)
//        {
//            _context = context;
//        }

//        // GET: api/pacientes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacientes()
//        {
//            // Implementa lógica para obtener todos los pacientes y mapearlos a PacienteDTO
//            var pacientes = await _context.Pacientes.ToListAsync();
//            var pacientesDTO = pacientes.Select(MapPacienteToPacienteDTO);
//            return Ok(pacientesDTO);
//        }

//        // GET: api/pacientes/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<PacienteDTO>> GetPaciente(int id)
//        {
//            // Implementa lógica para obtener un paciente por su ID y mapearlo a PacienteDTO
//            var paciente = await _context.Pacientes.FindAsync(id);

//            if (paciente == null)
//            {
//                return NotFound();
//            }

//            var pacienteDTO = MapPacienteToPacienteDTO(paciente);
//            return Ok(pacienteDTO);
//        }


//        [HttpGet("{id}/pacientes")]
//        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacientesByTutorId(int id)
//        {
//            var pacientes = await _context.Pacientes
//                .Where(p => p.TutorId == id)
//                .ToListAsync();

//            if (pacientes == null)
//            {
//                return NotFound();
//            }

//            // Mapea los pacientes a PacienteDTO
//            var pacientesDTO = pacientes.Select(p => MapPacienteToPacienteDTO(p)).ToList();

//            return pacientesDTO;
//        }


//        // POST: api/pacientes
//        [HttpPost]
//        public async Task<ActionResult<PacienteDTO>> PostPaciente(PacienteDTO pacienteDTO)
//        {
//            // Implementa lógica para crear un nuevo paciente a partir de PacienteDTO y guardarlo en la base de datos
//            var paciente = MapPacienteDTOToPaciente(pacienteDTO);
//            _context.Pacientes.Add(paciente);
//            await _context.SaveChangesAsync();

//            // Mapea el paciente creado a PacienteDTO y devuelve CreatedAtAction
//            pacienteDTO = MapPacienteToPacienteDTO(paciente);
//            return CreatedAtAction("GetPaciente", new { id = paciente.PacienteId }, pacienteDTO);
//        }

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
//}
