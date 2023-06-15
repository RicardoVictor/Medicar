using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Respositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Domain.Respositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly Context _context;

        public MedicoRepository([FromServices] Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetAsync()
        {
            return await _context.Medicos.AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _context.Medicos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Medico> GetByCRMAsync(int CRM)
        {
            return await _context.Medicos.AsNoTracking().FirstOrDefaultAsync(x => x.CRM == CRM);
        }

        public async Task<bool> ExistsWithCRMAsync(int CRM)
        {
            return await _context.Medicos.AnyAsync(x => x.CRM == CRM);
        }

        public async Task PostAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);

            if (medico != null)
                _context.Medicos.Remove(medico);

            await _context.SaveChangesAsync();
        }
    }
}
