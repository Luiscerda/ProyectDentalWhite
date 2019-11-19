using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dental_White.Moduls;
namespace Dental_White.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraController : ControllerBase
    {
        private readonly DentalWhiteContext _context;

        public HoraController(DentalWhiteContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hora>>> GetHoras()
        {
            return await _context.Horas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hora>> GetHoraItem(int id)
        {
            var horaItem = await _context.Horas.FindAsync(id);
            if (horaItem == null)
            {
                return NotFound();
            }
            return horaItem;
        }

        [HttpPost]
        public async Task<ActionResult<Hora>> PostHora(Hora hora){
            _context.Horas.Add(hora);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof (GetHoraItem), new {id = hora.Id}, hora);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHora(int id, Hora hora){
            if (id != hora.Id)
            {
                return BadRequest();
            }
            _context.Entry(hora).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHora(int id){
            var horaItem = await _context.Horas.FindAsync(id);
            if (horaItem == null)
            {
                return NotFound();
            }
            _context.Horas.Remove(horaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}