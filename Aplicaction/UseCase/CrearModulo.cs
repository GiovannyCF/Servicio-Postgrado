using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CrearModulo
    {
        private readonly InterfacesModulo _modulo;

        public CrearModulo(InterfacesModulo modulo)
        {
            _modulo = modulo;
        }

        public async Task EjecutarAsync(Modulo modulo)
        {
            ValidarModulo(modulo);
            if (modulo.Id == Guid.Empty) modulo.Id = Guid.NewGuid();

            await _modulo.Create(modulo);
        }

        private void ValidarModulo(Modulo modulo)
        {
            if (string.IsNullOrWhiteSpace(modulo.Nombre))
                throw new ArgumentException("El nombre del módulo es obligatorio.");

            if (modulo.DiplomadoId == Guid.Empty)
                throw new ArgumentException("El módulo debe pertenecer a un Diplomado.");

            if (modulo.DocenteId == Guid.Empty)
                throw new ArgumentException("El módulo debe tener un Docente asignado.");

            if (modulo.FechaFin < modulo.FechaInicio)
                throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.");
        }
    }
}