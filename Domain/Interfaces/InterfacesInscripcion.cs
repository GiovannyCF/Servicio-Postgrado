using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesInscripcion
    {
        Task<Inscripcion> GetById(Guid id);
        Task<IEnumerable<Inscripcion>> GetAll();
        Task Create(Inscripcion inscripcion);
        Task Update(Inscripcion inscripcion);
        Task Delete(Guid id);
    }
}
