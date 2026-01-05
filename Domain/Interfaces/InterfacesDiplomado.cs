using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesDiplomado
    {
        Task<Diplomado> GetById(Guid id);
        Task<IEnumerable<Diplomado>> GetAll();
        Task Create(Diplomado diplomado);
        Task Update(Diplomado diplomado);
        Task Delete(Guid id);
    }
}
