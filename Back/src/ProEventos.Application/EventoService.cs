using ProEventos.Application.Service;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersist _persist;

        public EventoService(IEventoPersist persist)
        {
            _persist = persist;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _persist.Add<Evento>(model);
                if (await _persist.SaveChangesAsync())
                    return await _persist.GetAllEventosAsyncById(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(Evento model)
        {
            try
            {
                var evento = await _persist.GetAllEventosAsyncById(model.Id,false);
                if (evento is null) return null;

                _persist.Update(model);
                if (await _persist.SaveChangesAsync())
                    return await _persist.GetAllEventosAsyncById(model.Id, false);

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
                var evento = await _persist.GetAllEventosAsyncById(eventoId, false);
                if (evento is null) throw new Exception("Evento não encontrado");

                _persist.Delete(evento);
                return await _persist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await _persist.GetAllEventosAsync(includePalestrantes);
                if (eventos is null)
                {
                    return null;
                }
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosAsyncById(int eventoId, bool includePalestrantes)
        {
            try
            {
                var evento = await _persist.GetAllEventosAsyncById(eventoId, includePalestrantes);
                if (evento is null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _persist.GetAllEventosAsyncByTema(tema,includePalestrantes);
                if (eventos is null)
                {
                    return null;
                }
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
