using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class ModulosDTOs
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Guid DiplomadoId { get; set; }
        public Guid DocenteId { get; set; }
    }
    public class CrearModuloDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Guid DiplomadoId { get; set; }
        public Guid DocenteId { get; set; }
    }
}
