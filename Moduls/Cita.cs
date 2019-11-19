using System.Collections.Generic;
namespace Dental_White.Moduls
{
    public class Cita
    {
        public int Id { get; set; }
        public string Fecha { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente  {get; set; }
        
        public int DoctorId {get; set;}
        public Doctor Doctor { get; set; }
        //public ICollection<Paciente> Pacientes { get; set; }
        //public ICollection<Doctor> Doctores { get; set; }
        //public ICollection<Hora> Horas { get; set; }
        
    }
}