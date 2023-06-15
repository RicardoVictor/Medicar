using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Handlers.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaResponse>> GetAsync();
        Task PostAsync(ConsultaRequest consulta);
        Task DeleteAsync(int id);
    }
}
