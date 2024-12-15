using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : Persistence<Palestrante>, IPalestrantePersistence
    {
        public PalestrantePersistence(ProEventosContext context) : base(context)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<bool> ExistById(int palestranteId)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsQueryable();
            query = query.Where(p => p.Id == palestranteId);
            return await query.AnyAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
