using AutoMapper;
using ProEventos.Application.Service;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;
using System;
using System.Threading.Tasks;
using ProEventos.Persistence.Repository;

namespace ProLotes.Application
{
    public class LoteService : ILoteService
    {
        private readonly GeralPersist _geralPersist;
        private readonly ILotePersist _lotePersist;
        private readonly IMapper _mapper;

        public LoteService(GeralPersist geralPersist, ILotePersist lotePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _lotePersist = lotePersist;
            _mapper = mapper;
        }

        public async Task<LoteDto> GetLoteByIdAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.GetLoteByIdsAsync(eventoId, loteId);
                if (lote is null) return null;

                return _mapper.Map<LoteDto>(lote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public async Task<LoteDto[]> GetLotesByEventosIdAsync(int loteId)
        {
            try
            {
                var lotes = await _lotePersist.GetLotesByEventosIdAsync(loteId);
                if (lotes is null) return null; 

                return _mapper.Map<LoteDto[]>(lotes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.GetLoteByIdsAsync(loteId,eventoId);
                if (lote is null) throw new Exception("Lote não encontrado");

                _geralPersist.Delete<Lote>(lote);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<LoteDto> SaveLote(int eventoId, LoteDto[] models)
        {
            try
            {
                var model = _mapper.Map<Lote>(dto);
                _persist.Add<Evento>(model);

                if (await _persist.SaveChangesAsync())
                    return _mapper.Map<EventoDto>(await _persist.GetEventoByIdAsync(model.Id, false));

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
