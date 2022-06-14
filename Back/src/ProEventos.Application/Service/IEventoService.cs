using ProEventos.Application.Dtos;
using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Service
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto model);
        Task<EventoDto> UpdateEvento(EventoDto model);
        Task<bool> DeleteEvento(int eventoId);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes);
        Task<EventoDto[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);
        Task<EventoDto> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}
