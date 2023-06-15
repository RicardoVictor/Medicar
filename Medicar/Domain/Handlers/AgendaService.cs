using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Commands.Responses;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medicar.Domain.Handlers.Interfaces;
using Medicar.Domain.Respositories.Interfaces;

namespace Medicar.Domain.Handlers
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicoRepository _medicoRepository;

        public AgendaService(IAgendaRepository agendaRepository, IMedicoRepository medicoRepository)
        {
            _agendaRepository = agendaRepository;
            _medicoRepository = medicoRepository;
        }


        public async Task<IEnumerable<AgendaResponse>> GetAsync(AgendaFilter filter)
        {
            var agendas = await _agendaRepository.GetAsync(filter);
            var response = new List<AgendaResponse>();

            foreach (var agenda in agendas)
            {
                response.Add(new AgendaResponse
                {
                    Id = agenda.Id,
                    Medico = agenda.Medico,
                    Dia = agenda.Dia,
                    Horarios = agenda.Horarios.Select(x => x.Horario.ToString()).ToList(),
                });
            }

            return response.OrderBy(x => x.Dia);
        }

        public async Task PostAsync(AgendaRequest agendaView)
        {
            if (agendaView.MedicoCRM == null)
                throw new Exception("CRM do médico é obrigatório.");

            if (agendaView.Dia == default)
                throw new Exception("Dia é obrigatório.");

            if (DateOnly.FromDateTime(agendaView.Dia) < DateOnly.FromDateTime(DateTime.Now))
                throw new Exception("Não é possível criar uma agenda para um dia passado.");

            if (agendaView.Horarios == null)
                throw new Exception("Horários é obrigatório.");

            if (agendaView.Horarios?.Count <= 0)
                throw new Exception("Horários é obrigatório.");

            if (await _agendaRepository.ExistsWithCRMAndDiaAsync(agendaView.MedicoCRM, DateOnly.FromDateTime(agendaView.Dia)))
                throw new Exception("Agenda já cadastrado para esse médico nesse dia.");

            var medico = await _medicoRepository.GetByCRMAsync(agendaView.MedicoCRM);

            if (medico == null)
                throw new Exception("Médico não encontrado.");

            var agenda = new Agenda()
            {
                MedicoId = medico.Id,
                Dia = DateOnly.FromDateTime(agendaView.Dia)
            };

            var agendaId = await _agendaRepository.PostAsync(agenda);

            var horarios = new List<HorarioAgenda>();

            agendaView.Horarios.ForEach(horario => horarios.Add(new HorarioAgenda()
            {
                Horario = TimeOnly.Parse(horario),
                AgendaId = agendaId
            }));

            await _agendaRepository.PostHorariosAsync(horarios);
        }
    }
}
