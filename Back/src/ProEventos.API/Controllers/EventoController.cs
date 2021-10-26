using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public EventoController()
        {
            
        }

        [HttpGet]
        public Evento Get()
        {
            return new Evento() ;
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Exemplo de delete" + id;
        }
    }
}
