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

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return context.Eventos;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return context.Eventos.Where(evento => evento.EventoId == id).FirstOrDefault();
        }

    }
}
