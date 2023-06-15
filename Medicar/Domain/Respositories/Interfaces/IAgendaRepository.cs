using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Domain.Respositories.Interfaces
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Agenda>> GetAsync();
        Task<Agenda> GetByIdAsync(int id);
        Task<IEnumerable<Agenda>> GetAsync(AgendaFilter filter);
        Task<bool> ExistsWithCRMAndDiaAsync(int CRM, DateOnly dia);
        Task<int> PostAsync(Agenda agenda);
        Task PostHorariosAsync(List<HorarioAgenda> horarios);
    }
}
