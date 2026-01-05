using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class EstudianteDTOs
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Ci { get; set; } = string.Empty;
        public string TituloProfesionalUrl { get; set; } = string.Empty;
        public string TituloProvisionNacionalUrl { get; set; } = string.Empty;
        public string CertificadoNacimientoUrl { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
    }
    public class CrearEstudianteDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Ci { get; set; } = string.Empty;
        public string TituloProfesionalUrl { get; set; } = string.Empty;
        public string TituloProvisionNacionalUrl { get; set; } = string.Empty;
        public string CertificadoNacimientoUrl { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
    }
}
