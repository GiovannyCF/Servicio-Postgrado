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
        public Guid DiplomadoId { get; set; }
        public Diplomado? Diplomado { get; set; }

        public Guid DocenteId { get; set; }
        public Docente? Docente { get; set; }
    }
}