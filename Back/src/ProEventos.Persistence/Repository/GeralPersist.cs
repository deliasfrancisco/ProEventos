using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interface;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repository
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext _context;

        public GeralPersist(ProEventosContext context)
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

		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync()) > 0; // Como retorna um bool, ele retornará verdadeiro se for maior que 0
		}

		public void DeleteRange<T>(T[] entityArray) where T : class
		{
			_context.RemoveRange(entityArray);
		}
	}
}
