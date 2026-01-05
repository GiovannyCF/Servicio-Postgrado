using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class DocenteDTOs
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string CurriculumUrl { get; set; } = string.Empty;
    }
    public class CrearDocenteDTOs
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string CurriculumUrl { get; set; } = string.Empty;
    }
}
