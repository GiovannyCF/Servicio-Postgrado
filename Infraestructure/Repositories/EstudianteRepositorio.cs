using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EstudianteRepositorio : InterfacesEstudiante
    {
        private readonly AppDbContext _context;

        public EstudianteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAll()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante> GetById(Guid id)
        {   
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task Create(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Estudiante estudiante)
        {
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }
    }
}