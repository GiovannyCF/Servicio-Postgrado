using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Docente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string Curriculum { get; set; } = string.Empty;
        public ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();


    }
}
