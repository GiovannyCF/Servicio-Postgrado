using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotaRepositorio : InterfacesNota
    {
        private readonly AppDbContext _context;

        public NotaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nota>> GetAll()
        {
            return await _context.Notas
                .Include(n => n.Inscripcion)
                .Include(n => n.Modulo)
                .ToListAsync();
        }

        public async Task<Nota> GetById(Guid id)
        {
            return await _context.Notas
                .Include(n => n.Inscripcion)
                .Include(n => n.Modulo)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task Create(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Nota nota)
        {
            _context.Entry(nota).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
        }
    }
}