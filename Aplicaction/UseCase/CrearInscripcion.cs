using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class CrearInscripcion
    {
        private readonly InterfacesInscripcion _inscripcion;

        public CrearInscripcion(InterfacesInscripcion inscripcion)
        {
            _inscripcion = inscripcion;
        }

        public async Task EjecutarAsync(Inscripcion inscripcion)
        {
            ValidarInscripcion(inscripcion);

            if (inscripcion.Id == Guid.Empty) inscripcion.Id = Guid.NewGuid();
            if (inscripcion.FechaInscripcion == default) inscripcion.FechaInscripcion = DateTime.Now;

            await _inscripcion.Create(inscripcion);
        }

        private void ValidarInscripcion(Inscripcion inscripcion)
        {
            if (inscripcion.EstudianteId == Guid.Empty)
                throw new ArgumentException("Se requiere un Estudiante válido.");

            if (inscripcion.DiplomadoId == Guid.Empty)
                throw new ArgumentException("Se requiere un Diplomado válido.");
        }
    }
}