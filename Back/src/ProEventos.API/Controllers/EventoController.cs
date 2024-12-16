using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Contratos;
using ProEventos.Application.Exceptions;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Evento model)
        {
            try
            {
                Evento evento = await _eventoService.Add(model);
                if (evento != null)
                {
                    return Created($"{Request.Path}/{evento.Id}", evento);
                }
                return BadRequest("Não foi possível inserir no banco de dados!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Evento[] eventos = await _eventoService.GetAllEventosAsync(true);
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Evento evento = await _eventoService.GetEventoByIdAsync(id, true);
                return Ok(evento);
            }
            catch (EventoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                Evento[] eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evento model)
        {
            try
            {
                Evento evento = await _eventoService.Update(id, model);
                if (evento != null)
                {
                    return Ok(evento);
                }
                return BadRequest("Não foi possível atualizar no banco de dados!");
            }
            catch (EventoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool resultado = await _eventoService.Delete(id);
                if (resultado)
                {
                    return NoContent();
                }
                return BadRequest("Não foi possível excluir no banco de dados!");
            }
            catch (EventoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
