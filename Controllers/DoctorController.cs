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
            var doctorItem = await _context.Doctores.FindAsync(doctor.Identificacion_Doctor);
            if (doctorItem != null)
            {
                return BadRequest();
            }
            else
            {
                _context.Doctores.Add(doctor);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof (GetDoctorItem), new {id = doctor.Identificacion_Doctor}, doctor);
            }   
        }

        [HttpGet("{identificacion}")]
        public async Task<ActionResult<Doctor>> GetDoctorItem(string identificacion)
        {
            var doctorItem = await _context.Doctores.FindAsync(identificacion);
            if (doctorItem == null)
            {
                return NotFound();
            }
            return doctorItem;
        }

        [HttpPut("{cedula}")]
        public async Task<IActionResult> PutDoctor(string cedula, Doctor doctor){
            if (cedula != doctor.Identificacion_Doctor)
            {
                return BadRequest();
            }
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{cedula}")]
        public async Task<IActionResult> DeleteDoctor(string cedula){
            var doctorItem = await _context.Doctores.FindAsync(cedula);
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