using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
namespace Dental_White.Moduls
{
    [Table("CITA")]
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("FK_PACIENTE")]
        public string Identificacion_Paciente { get; set; }
        public virtual Paciente Paciente  {get; set; }
        
        [ForeignKey("FK_DOCTOR")] 
        public string Identificacion_Doctor {get; set;}
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("FK_HORA")]
        public int Id_Cita { get; set; }
        public virtual Hora Hora { get; set; }

        
    }
}