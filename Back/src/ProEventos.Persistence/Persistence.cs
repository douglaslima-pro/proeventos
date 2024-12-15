using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public abstract class Persistence<TEntity> : IPersistence<TEntity> where TEntity : class
    {
        protected readonly ProEventosContext _context;
        public Persistence (ProEventosContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(TEntity[] entities)
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
