using Medicar.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Data.Configurations
{
    public class HorarioAgendaConfiguration : IEntityTypeConfiguration<HorarioAgenda>
    {
        public void Configure(EntityTypeBuilder<HorarioAgenda> builder)
        {
            builder
                .HasOne(a => a.Agenda)
                .WithMany(x => x.Horarios)
                .HasForeignKey(a => a.AgendaId);
        }
    }
}
