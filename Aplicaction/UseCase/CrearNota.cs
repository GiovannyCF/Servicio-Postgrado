using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class CrearNota
    {
        private readonly InterfacesNota _nota;

        public CrearNota(InterfacesNota nota)
        {
            _nota = nota;
        }

        public async Task EjecutarAsync(Nota nota)
        {
            ValidarNota(nota);
            if (nota.Id == Guid.Empty) nota.Id = Guid.NewGuid();

            await _nota.Create(nota);
        }

        private void ValidarNota(Nota nota)
        {
            if (nota.Valor < 0 || nota.Valor > 100)
                throw new ArgumentException("La nota debe estar entre 0 y 100.");

            if (nota.InscripcionId == Guid.Empty)
                throw new ArgumentException("La nota debe estar asociada a una Inscripción.");

            if (nota.ModuloId == Guid.Empty)
                throw new ArgumentException("La nota debe estar asociada a un Módulo.");
        }
    }
}