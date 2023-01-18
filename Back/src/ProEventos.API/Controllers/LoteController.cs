using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    public class LoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoteService _service;

        public LoteController(IMapper mapper, ILoteService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eventos = await _service.GetLotesByEventoAsync(true);

                if (eventos is null) return NotFound("Nenhum evento encontrado");
                var results = _mapper.Map<LoteDto[]>(eventos); // Add o IEnumerable quando o mapeamento receber como parametro uma lista

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, LoteDto[] models)
        {
            try
            {
                var eventos = await _service.UpdateEvento(models);

                if (eventos is null) return BadRequest("Erro ao adicionar");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
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
