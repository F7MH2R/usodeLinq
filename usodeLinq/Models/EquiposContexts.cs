using Microsoft.EntityFrameworkCore;

namespace usodeLinq.Models
{
    public class EquiposContexts: DbContext
    {
        public EquiposContexts(DbContextOptions<EquiposContexts>options):base (options) 
        { 
        
        }

        public DbSet<Equipos> equipos { get; set; }
        public DbSet<estadoEquipo> estados_equipo { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<TipoEquipo> tipo_equipo { get; set; }
 
    }
}
