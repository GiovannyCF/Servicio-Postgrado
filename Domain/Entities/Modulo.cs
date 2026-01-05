using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Modulo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiplomadoId { get; set; }
        public Diplomado? Diplomado { get; set; }

        public int DocenteId { get; set; }
        public Docente? Docente { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
