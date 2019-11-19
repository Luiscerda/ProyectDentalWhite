using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dental_White.Moduls;
namespace Dental_White.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DentalWhiteContext _context;

        public DoctorController(DentalWhiteContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctores()
        {
            return await _context.Doctores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor){
            _context.Doctores.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof (GetDoctorItem), new {id = doctor.Id}, doctor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorItem(int id)
        {
            var doctorItem = await _context.Doctores.FindAsync(id);
            if (doctorItem == null)
            {
                return NotFound();
            }
            return doctorItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor){
            if (id != doctor.Id)
            {
                return BadRequest();
            }
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id){
            var doctorItem = await _context.Doctores.FindAsync(id);
            if (doctorItem == null)
            {
                return NotFound();
            }
            _context.Doctores.Remove(doctorItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}