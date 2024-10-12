using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;

using ProEventos.API.Models;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public ApplicationContext context;

        public EventoController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> GetAll()
        {
            return context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPut("{id}")]
        public Evento Put(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpDelete("{id}")]
        public Evento Delete(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

    }
}
