using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Commands.Responses;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Handlers.Interfaces
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaResponse>> GetAsync(AgendaFilter filter);
        Task PostAsync(AgendaRequest medico);
    }
}
