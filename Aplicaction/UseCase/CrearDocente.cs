using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class CrearDocente
    {
        private readonly InterfacesDocente _docente;

        public CrearDocente(InterfacesDocente docente)
        {
            _docente = docente;
        }

        public async Task EjecutarAsync(Docente docente)
        {
            ValidarDocente(docente);
            if (docente.Id == Guid.Empty) docente.Id = Guid.NewGuid();

            await _docente.Create(docente);
        }

        private void ValidarDocente(Docente docente)
        {
            if (string.IsNullOrWhiteSpace(docente.Nombre))
                throw new ArgumentException("El nombre del docente es obligatorio.");

            if (string.IsNullOrWhiteSpace(docente.Apellido))
                throw new ArgumentException("El apellido del docente es obligatorio.");

            if (string.IsNullOrWhiteSpace(docente.Email))
                throw new ArgumentException("El correo electrónico es obligatorio.");
        }
    }
}