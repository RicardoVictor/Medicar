using Medicar.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicar.Data.Configurations
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder
                .HasOne(a => a.Medico)
                .WithMany()
                .HasForeignKey(a => a.MedicoId);
        }
    }
}
