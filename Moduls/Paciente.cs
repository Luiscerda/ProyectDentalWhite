using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace Dental_White.Moduls
{
    public class Paciente : Persona
    {
        public string TipoId { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }

        public virtual List<Cita> Citas { get; set; }
        

        //public int CitaId { get; set; }
        //public Cita Cita { get; set; }
        
    }
}