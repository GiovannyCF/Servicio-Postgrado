using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Diplomado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty; 
        public string NroActa { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }         
        public DateTime FechaFin { get; set; }
        public ICollection<Modulo> Modulos {get; set; } = new List<Modulo>();
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    }
}
