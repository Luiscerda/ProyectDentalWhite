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
        [Required]
        public string Fecha { get; set; }

        public string Identificacion_Paciente { get; set; }
        [ForeignKey("Identificacion_Paciente")]
        public virtual Paciente Paciente  {get; set; }

        public string Identificacion_Doctor { get; set; }
        [ForeignKey("Identificacion_Doctor")]
        public  Doctor Doctor { get; set; }

        public string Horario { get; set; }
        [ForeignKey("Horario")]
        public virtual Hora Hora { get; set; }

        
    }
}