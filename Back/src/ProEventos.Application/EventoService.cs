using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Application.Exceptions;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        public EventoService(IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
        }

        public async Task<Evento> Add(Evento model)
        {
            try
            {
                _eventoPersistence.Add(model);
                if (await _eventoPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> Update(int eventoId, Evento model)
        {
            try
            {
                bool eventoExiste = await _eventoPersistence.ExistById(eventoId);
                if (!eventoExiste)
                {
                    throw new EventoNaoEncontradoException("Evento não encontrado!");
                }
                model.Id = eventoId;
                _eventoPersistence.Update(model);
                if (await _eventoPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(eventoId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int eventoId)
        {
            try
            {
                Evento evento = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                if (evento == null)
                {
                    throw new EventoNaoEncontradoException("Evento não encontrado!");
                }
                _eventoPersistence.Delete(evento);
                return await _eventoPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                Evento[] eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                Evento[] eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                Evento evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null)
                {
                    throw new EventoNaoEncontradoException("Evento não encontrado!");
                }
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
