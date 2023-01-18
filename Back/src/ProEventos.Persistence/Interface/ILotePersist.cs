using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface ILotePersist
    {
        Task<Lote[]> GetLotesByEventosIdAsync(int id);
        Task<Lote> GetLoteByIdsAsync(int loteId, int eventoId);
        Task<LoteDto> SaveLotes(int eventoId, LoteDto[] models);
        Task<LoteDto> DeleteLote(int eventoId,int loteId);
        Task<LoteDto[]> GetLotesByEventosIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdAsync(int eventoId, int loteId);
    }
}
