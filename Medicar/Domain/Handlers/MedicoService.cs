using Medicar.Data;
using Medicar.Domain;
using Medicar.Domain.Commands.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medicar.Domain.Handlers.Interfaces;
using Medicar.Domain.Respositories.Interfaces;

namespace Medicar.Domain.Handlers
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<Medico>> GetAsync()
        {
            return await _medicoRepository.GetAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _medicoRepository.GetByIdAsync(id);
        }

        public async Task PostAsync(MedicoRequest medicoView)
        {
            if (string.IsNullOrWhiteSpace(medicoView.Nome))
                throw new Exception("Nome é obrigatório.");

            if (medicoView.CRM == null)
                throw new Exception("CRM é obrigatório.");

            if (await _medicoRepository.ExistsWithCRMAsync(medicoView.CRM))
                throw new Exception("CRM já cadastrado.");

            var medico = new Medico()
            {
                Nome = medicoView.Nome,
                CRM = medicoView.CRM,
                email = medicoView.email
            };

            await _medicoRepository.PostAsync(medico);
        }

        public async Task DeleteAsync(int id)
        {
            await _medicoRepository.DeleteAsync(id);
        }
    }
}
