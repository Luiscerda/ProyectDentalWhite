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
    public class TratamientoController : ControllerBase
    {
        private readonly DentalWhiteContext _context;

        public TratamientoController(DentalWhiteContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamientos()
        {
            return await _context.Tratamientos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento){
            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof (GetTratamientoItem), new {id = tratamiento.Id}, tratamiento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tratamiento>> GetTratamientoItem(int id)
        {
            var tratamientoItem = await _context.Tratamientos.FindAsync(id);
            if (tratamientoItem == null)
            {
                return NotFound();
            }
            return tratamientoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamiento(int id, Tratamiento tratamiento){
            if (id != tratamiento.Id)
            {
                return BadRequest();
            }
            _context.Entry(tratamiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTratamiento(int id){
            var tratamientoItem = await _context.Tratamientos.FindAsync(id);
            if (tratamientoItem == null)
            {
                return NotFound();
            }
            _context.Tratamientos.Remove(tratamientoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}