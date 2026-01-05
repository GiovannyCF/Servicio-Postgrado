using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DocenteRepositorio : InterfacesDocente
    {
        private readonly AppDbContext _context;

        public DocenteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Docente>> GetAll()
        {
            return await _context.Docentes.ToListAsync();
        }

        public async Task<Docente> GetById(Guid id)
        {
            return await _context.Docentes.FindAsync(id);
        }

        public async Task Create(Docente docente)
        {
            await _context.Docentes.AddAsync(docente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Docente docente)
        {
            _context.Entry(docente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            if (docente != null)
            {
                _context.Docentes.Remove(docente);
                await _context.SaveChangesAsync();
            }
        }
    }
}