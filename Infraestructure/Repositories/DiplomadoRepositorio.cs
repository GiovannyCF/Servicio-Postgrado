using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DiplomadoRepositorio : InterfacesDiplomado
    {
        private readonly AppDbContext _context;

        public DiplomadoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Diplomado>> GetAll()
        {
            return await _context.Diplomados.ToListAsync();
        }

        public async Task<Diplomado> GetById(Guid id)
        {
            return await _context.Diplomados.FindAsync(id);
        }

        public async Task Create(Diplomado diplomado)
        {
            await _context.Diplomados.AddAsync(diplomado);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Diplomado diplomado)
        {
            _context.Entry(diplomado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var diplomado = await _context.Diplomados.FindAsync(id);
            if (diplomado != null)
            {
                _context.Diplomados.Remove(diplomado);
                await _context.SaveChangesAsync();
            }
        }
    }
}