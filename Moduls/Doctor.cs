using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dental_White.Moduls
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string Identificacion_Doctor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono2 { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        public virtual List<Cita> Citas { get; set; }
    }
}