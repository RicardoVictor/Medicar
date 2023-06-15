using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Respositories.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> GetAsync();
        Task PostAsync(Consulta consulta);
        Task DeleteAsync(int id);
    }
}
