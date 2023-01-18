using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repository
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (includePalestrantes)
            {
                query = query.AsNoTracking()
                    .Include(p => p.PalestrantesEventos) // se for verdadeiro irá incluir o palestrante porem somente o id
                    .ThenInclude(p => p.Palestrante); // então inclua tambem o palestrante
            }

            query = query.OrderByDescending(c => c.DataEvento).Where(c => c.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(p => p.PalestrantesEventos) // se for verdadeiro irá incluir o palestrante porem somente o id
                    .ThenInclude(p => p.Palestrante); // então inclua tambem o palestrante
            }

            query = query.AsNoTracking()
                .OrderByDescending(c => c.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (includePalestrantes)
            {
                query = query.AsNoTracking()
                    .Include(p => p.PalestrantesEventos) // se for verdadeiro irá incluir o palestrante porem somente o id
                    .ThenInclude(p => p.Palestrante); // então inclua tambem o palestrante
            }

            query = query.OrderByDescending(c => c.DataEvento).Where(c => c.Tema.ToLower().Contains(tema));
            return await query.ToArrayAsync();
        }
    }
}
