using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InscripcionRepositorio : InterfacesInscripcion
    {
        private readonly AppDbContext _context;

        public InscripcionRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inscripcion>> GetAll()
        {
            return await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Diplomado)
                .ToListAsync();
        }

        public async Task<Inscripcion> GetById(Guid id)
        {
            return await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Diplomado)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Create(Inscripcion inscripcion)
        {
            await _context.Inscripciones.AddAsync(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Inscripcion inscripcion)
        {
            _context.Entry(inscripcion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripciones.Remove(inscripcion);
                await _context.SaveChangesAsync();
            }
        }
    }
}