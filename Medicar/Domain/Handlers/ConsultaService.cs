using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medicar.Domain.Handlers.Interfaces;
using Medicar.Domain.Respositories.Interfaces;

namespace Medicar.Domain.Handlers
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicoRepository _medicoRepository;

        public ConsultaService(IConsultaRepository consultaRepository, IAgendaRepository agendaRepository, IMedicoRepository medicoRepository)
        {
            _consultaRepository = consultaRepository;
            _agendaRepository = agendaRepository;
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<ConsultaResponse>> GetAsync()
        {
            var consultas = await _consultaRepository.GetAsync();
            var response = new List<ConsultaResponse>();

            foreach (var consulta in consultas)
            {
                if (consulta.Dia >= DateOnly.FromDateTime(DateTime.Now))
                {
                    if (consulta.Dia > DateOnly.FromDateTime(DateTime.Now) ||
                       consulta.Dia == DateOnly.FromDateTime(DateTime.Now) && consulta.Horario > TimeOnly.FromDateTime(DateTime.Now))
                    {
                        response.Add(new ConsultaResponse
                        {
                            Id = consulta.Id,
                            Dia = consulta.Dia,
                            Horario = consulta.Horario.ToString(),
                            DataAgendamento = consulta.DataAgendamento,
                            Medico = consulta.Medico,
                        });
                    }
                }
            }

            return response.OrderBy(x => x.Horario).OrderBy(x => x.Dia);
        }

        public async Task PostAsync(ConsultaRequest consultaRequest)
        {
            var agenda = await _agendaRepository.GetByIdAsync(consultaRequest.AgendaId);

            var consulta = new Consulta()
            {
                Dia = agenda.Dia,
                Horario = TimeOnly.Parse(consultaRequest.Horario),
                DataAgendamento = DateTime.Now,
                MedicoId = agenda.MedicoId
            };

            await _consultaRepository.PostAsync(consulta);
        }


        public async Task DeleteAsync(int id)
        {
            await _consultaRepository.DeleteAsync(id);
        }
    }
}
