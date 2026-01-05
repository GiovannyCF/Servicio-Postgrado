using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class InscripcionDTOs
    {
        public Guid Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public bool TerminoDiplomado { get; set; }
        public bool DiplomaEntregado { get; set; }
        public Guid EstudianteId { get; set; }
        public Guid DiplomadoId { get; set; }
    }
    public class CrearInscripcionDTO
    {
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        public bool TerminoDiplomado { get; set; } = false;
        public bool DiplomaEntregado { get; set; } = false;
        public Guid EstudianteId { get; set; }
        public Guid DiplomadoId { get; set; }
    }
}
