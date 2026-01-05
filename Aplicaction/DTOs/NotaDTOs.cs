using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.DTOs
{
    public class NotaDTOs
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public Guid InscripcionId { get; set; }
        public Guid ModuloId { get; set; }
    }
    public class CrearNotaDTO
    {
        public decimal Valor { get; set; }
        public Guid InscripcionId { get; set; }
        public Guid ModuloId { get; set; }
    }
}
