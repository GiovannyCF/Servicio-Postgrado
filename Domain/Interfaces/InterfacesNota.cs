using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesNota
    {
        Task<Nota> GetById(Guid id);
        Task<IEnumerable<Nota>> GetAll();
        Task Create(Nota nota);
        Task Update(Nota nota);
        Task Delete(Guid id);
    }
}
