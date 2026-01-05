using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface InterfacesEstudiante
    {
        Task<Estudiante> GetById(Guid id);
        Task<IEnumerable<Estudiante>> GetAll();
        Task Create(Estudiante estudiante);
        Task Update(Estudiante estudiante);
        Task Delete(Guid id);
    }
}
