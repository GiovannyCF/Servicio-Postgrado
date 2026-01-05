using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class CrearEstudiante
    {
        private readonly InterfacesEstudiante _estudiante;

        public CrearEstudiante(InterfacesEstudiante estudiante)
        {
            _estudiante = estudiante;
        }

        public async Task EjecutarAsync(Estudiante estudiante)
        {
            ValidarEstudiante(estudiante);
            if (estudiante.Id == Guid.Empty) estudiante.Id = Guid.NewGuid();

            await _estudiante.Create(estudiante);
        }

        private void ValidarEstudiante(Estudiante estudiante)
        {
            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.Apellido))
                throw new ArgumentException("El apellido del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.Ci))
                throw new ArgumentException("El C.I. es obligatorio.");
        }
    }
}