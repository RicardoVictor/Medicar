using Medicar.Data.Configurations;
using Medicar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Data
{
    public class Context : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<HorarioAgenda> Horarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendaConfiguration());
            modelBuilder.ApplyConfiguration(new HorarioAgendaConfiguration());
        }
    }
}
