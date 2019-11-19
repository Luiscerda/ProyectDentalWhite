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
    public class CitaController : ControllerBase
    {
        private readonly DentalWhiteContext _context;

        public CitaController(DentalWhiteContext context){
            _context = context;
           
             
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.Citas.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostCita(Cita cita){
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof (GetCitaItem), new {id = cita.Id}, cita);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCitaItem(int id)
        {
            var citaItem =  _context.Citas.Where(c => c.Id==id).Include(c => c.Paciente).Include(c => c.Doctor).FirstOrDefault();
            if (citaItem == null)
            {
                return NotFound();
            }
            return citaItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita){
            if (id != cita.Id)
            {
                return BadRequest();
            }
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id){
            var citaItem = await _context.Citas.FindAsync(id);
            if (citaItem == null)
            {
                return NotFound();
            }
            _context.Citas.Remove(citaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}