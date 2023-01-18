using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repository
{
    public class LotePersist : ILotePersist
    {
        private readonly ProEventosContext _context;

        public LotePersist(ProEventosContext context)
        {
            _context = context;
        }

        public Task<Lote[]> GetLotesByEventosIdAsync(int id)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query.AsNoTracking()
                    .Where(lote => lote.EventoId == id);

            return query.ToArrayAsync();
        }

        public Task<Lote> GetLoteByIdsAsync(int loteId, int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query.AsNoTracking()
                    .Where(lote => lote.EventoId == eventoId && lote.Id == loteId);

            return query.FirstOrDefaultAsync();
        }
    }
}
