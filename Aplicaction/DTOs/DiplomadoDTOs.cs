using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class DiplomadoDTOs
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string NroActa { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class CrearDiplomadoDTOs
    {
        public string Nombre { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string NroActa { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
