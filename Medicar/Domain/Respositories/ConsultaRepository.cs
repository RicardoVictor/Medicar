using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Respositories.Interfaces;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Domain.Respositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly Context _context;

        public ConsultaRepository([FromServices] Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetAsync()
        {
            return await _context.Consultas
                .Include(x => x.Medico)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task PostAsync(Consulta consulta)
        {
            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);

            if (medico != null)
                _context.Consultas.Remove(medico);

            await _context.SaveChangesAsync();
        }

        private async Task<Consulta> GetByIdAsync(int id)
        {
            return await _context.Consultas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
