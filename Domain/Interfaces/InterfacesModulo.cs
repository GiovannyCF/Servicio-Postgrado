using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesModulo
    {
        Task<Modulo> GetById(Guid id);
        Task<IEnumerable<Modulo>> GetAll();
        Task Create(Modulo modulo);
        Task Update(Modulo modulo);
        Task Delete(Guid id);
    }
}
