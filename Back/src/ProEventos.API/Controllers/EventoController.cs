using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using ProEventos.Application.Service;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;
        private readonly IMapper _mapper;

        public EventoController(IEventoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var eventos = await _service.GetAllEventosAsync(true);

                if (eventos is null)  return NotFound("Nenhum evento encontrado");
                var results = _mapper.Map<EventoDto[]>(eventos); // Add o IEnumerable quando o mapeamento receber como parametro uma lista

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _service.GetEventoByIdAsync(id, false);

                if (evento is null) return NotFound("Nenhum evento encontrado"); 

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpGet("GetByTema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _service.GetAllEventosAsyncByTema(tema, false);

                if (evento is null) return NotFound("Nenhum evento encontrado por tema"); 

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var eventos = await _service.AddEvento(model);

                if (eventos is null) return BadRequest("Erro ao adicionar"); 

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(EventoDto model)
        {
            try
            {
                var eventos = await _service.UpdateEvento(model);

                if (eventos is null) return BadRequest("Erro ao adicionar"); 

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _service.DeleteEvento(id) ? Ok("Removido") : BadRequest("Erro ao remover");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }
    }
}
