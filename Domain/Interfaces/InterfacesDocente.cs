using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesDocente
    {
        Task<Docente> GetById(Guid id);
        Task<IEnumerable<Docente>> GetAll();
        Task Create(Docente docente);
        Task Update(Docente docente);
        Task Delete(Guid id);
    }
}
