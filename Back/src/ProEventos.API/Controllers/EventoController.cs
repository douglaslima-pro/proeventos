using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> eventos = new List<Evento>()
        {
            new Evento()
            {
                EventoId = 1,
                Local = "Belo Horizonte, MG",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "Angular e .NET 5",
                QtdPessoas = 250,
                Lote = "1° Lote",
                ImagemURL = "evento1.png"
            },
            new Evento()
            {
                EventoId = 2,
                Local = "São Paulo, SP",
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                Tema = "Angular e Suas Novidades",
                QtdPessoas = 350,
                Lote = "1° Lote",
                ImagemURL = "evento2.png"
            }
        };

        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return eventos.Where(evento => evento.EventoId == id).FirstOrDefault();
        }

    }
}
