using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Handlers.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> GetAsync();
        Task<Medico> GetByIdAsync(int id);
        Task PostAsync(MedicoRequest medico);
        Task DeleteAsync(int id);
    }
}
