using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Service;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersist _persist;
        private readonly IMapper _mapper;

        public EventoService(IEventoPersist persist, IMapper mapper)
        {
            _persist = persist;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEvento(EventoDto dto)
        {
            try
            {
                var model = _mapper.Map<Evento>(dto);
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

        public async Task<EventoDto> UpdateEvento(EventoDto model)
        {
            try
            {
                var evento = await _persist.GetEventoByIdAsync(model.Id,false);
                if (evento is null) return null;

                _persist.Update(model);
                if (await _persist.SaveChangesAsync())
                    return _mapper.Map<EventoDto>(await _persist.GetEventoByIdAsync(evento.Id, false));

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _persist.GetEventoByIdAsync(eventoId, false);
                if (evento is null) throw new Exception("Evento não encontrado");

                _persist.Delete(evento);
                return await _persist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await _persist.GetAllEventosAsync(includePalestrantes);
                if (eventos is null) return null; 

                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _persist.GetAllEventosAsyncByTema(tema,includePalestrantes);
                if (eventos is null) return null; 

                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            try
            {
                var evento = await _persist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento is null) return null;

                return _mapper.Map<EventoDto>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
