using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dental_White.Moduls;
namespace Dental_White.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DentalWhiteContext _context;

        public PacienteController(DentalWhiteContext context)
        {
            _context = context;
            if(_context.Pacientes.Count() == 0)
            {
                _context.Pacientes.Add(new Paciente { TipoId = "C.C", NumeroCedula = "1004279985", Nombres = "luis carlos", Apellidos = "Cerda ortiz", Direccion = "Villa catalina 2", Telefono="3003906802", FechaNacimiento = "23/05/1998", Edad=21  });
                //_context.TaskItems.Add(new TaskItem { Title = "Calendario el proyecto", Description = "Priorizar", Priority = true });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente){
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof (GetPacienteItem), new {id = paciente.Id}, paciente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteItem(int id)
        {
            var pacienteItem = await _context.Pacientes.FindAsync(id);
            if (pacienteItem == null)
            {
                return NotFound();
            }
            return pacienteItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacienteItem(int id, Paciente paciente){
            if (id != paciente.Id)
            {
                return BadRequest();
            }
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id){
            var pacienteItem = await _context.Pacientes.FindAsync(id);
            if (pacienteItem == null)
            {
                return NotFound();
            }
            _context.Pacientes.Remove(pacienteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}