using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ModuloRepositorio : InterfacesModulo
    {
        private readonly AppDbContext _context;

        public ModuloRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modulo>> GetAll()
        {
            return await _context.Modulos
                .Include(m => m.Diplomado)
                .Include(m => m.Docente)
                .ToListAsync();
        }

        public async Task<Modulo> GetById(Guid id)
        {
            return await _context.Modulos
                .Include(m => m.Diplomado)
                .Include(m => m.Docente)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Create(Modulo modulo)
        {
            await _context.Modulos.AddAsync(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Modulo modulo)
        {
            _context.Entry(modulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}