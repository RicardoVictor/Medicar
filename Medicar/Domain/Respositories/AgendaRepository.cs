using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Respositories.Interfaces;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Domain.Respositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly Context _context;

        public AgendaRepository([FromServices] Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agenda>> GetAsync()
        {
            return await _context.Agendas
                .Include(x => x.Medico)
                .Include(x => x.Horarios)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<Agenda> GetByIdAsync(int id)
        {
            return await _context.Agendas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<Agenda>> GetAsync(AgendaFilter filter)
        {
            return await _context.Agendas
                .Include(x => x.Medico)
                .Include(x => x.Horarios)
                .Where(x => filter.MedicoIds != null && filter.MedicoIds.Count > 0 ? filter.MedicoIds.Contains(x.MedicoId) : true)
                .Where(x => filter.MedicoCRMs != null && filter.MedicoCRMs.Count > 0 ? filter.MedicoCRMs.Contains(x.Medico.CRM) : true)
                .Where(x => filter.StartDate != default ? x.Dia >= DateOnly.FromDateTime(filter.StartDate) : true)
                .Where(x => filter.EndDate != default ? x.Dia <= DateOnly.FromDateTime(filter.EndDate) : true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistsWithCRMAndDiaAsync(int CRM, DateOnly dia)
        {
            return await _context.Agendas.AnyAsync(x => x.Medico.CRM == CRM && x.Dia == dia);
        }

        public async Task<int> PostAsync(Agenda agenda)
        {
            await _context.Agendas.AddAsync(agenda);
            await _context.SaveChangesAsync();
            return agenda.Id;
        }

        public async Task PostHorariosAsync(List<HorarioAgenda> horarios)
        {
            await _context.Horarios.AddRangeAsync(horarios);
            await _context.SaveChangesAsync();
        }
    }
}
