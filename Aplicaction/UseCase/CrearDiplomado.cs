using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class CrearDiplomado
    {
        private readonly InterfacesDiplomado _diplomado;

        public CrearDiplomado(InterfacesDiplomado diplomado)
        {
            _diplomado = diplomado;
        }

        public async Task EjecutarAsync(Diplomado diplomado)
        {
            ValidarDiplomado(diplomado);

            if (diplomado.Id == Guid.Empty)
            {
                diplomado.Id = Guid.NewGuid();
            }

            await _diplomado.Create(diplomado);
        }

        private void ValidarDiplomado(Diplomado diplomado)
        {
            if (string.IsNullOrWhiteSpace(diplomado.Nombre))
            {
                throw new ArgumentException("El nombre del diplomado es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(diplomado.Version))
            {
                throw new ArgumentException("La versión del diplomado es obligatoria.");
            }
            if (diplomado.Costo < 0)
            {
                throw new ArgumentException("El costo no puede ser negativo.");
            }
        }
    }
}