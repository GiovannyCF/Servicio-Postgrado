using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inscripcion
    {
        public Guid Id { get; set; }
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        public bool TerminoDiplomado { get; set; } = false;
        public bool DiplomaEntregado { get; set; } = false;
        public Guid EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }
        public Guid DiplomadoId { get; set; }
        public Diplomado? Diplomado { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
