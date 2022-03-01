using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestrantePersist : IGeralPersist
    {
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes);
        Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos);
        Task<Palestrante> GetAllPalestranteAsyncById(int PalestranteId, bool includeEventos);
    }
}
