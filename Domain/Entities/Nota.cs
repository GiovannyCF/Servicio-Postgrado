using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }

        public int ModuloId { get; set; }
        public Modulo? Modulo { get; set; }
    }
}
