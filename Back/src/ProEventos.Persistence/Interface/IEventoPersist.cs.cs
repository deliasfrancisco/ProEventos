using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IEventoPersist : IGeralPersist
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}
