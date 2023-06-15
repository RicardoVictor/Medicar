using Medicar.Data;
using Medicar.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Respositories.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAsync();
        Task<Medico> GetByIdAsync(int id);
        Task<Medico> GetByCRMAsync(int CRM);
        Task<bool> ExistsWithCRMAsync(int CRM);
        Task PostAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
