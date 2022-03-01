using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PalestranteEvento>().HasKey(x => new { x.EventoId,x.PalestranteId});

            builder.Entity<Evento>()
                .HasMany(e => e.RedeSociais)
                .WithOne(r => r.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Palestrante>()
                .HasMany(e => e.RedeSociais)
                .WithOne(r => r.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
