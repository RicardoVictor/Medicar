using Medicar.Domain;
using Medicar.Domain.Handlers;
using Medicar.Domain.Handlers.Interfaces;
using Medicar.Domain.Respositories.Interfaces;
using Moq;
using Xunit;

namespace Medicar.Testes
{
    public class MedicoServiceUnitTests
    {
        private readonly IMedicoService _service;
        private readonly Mock<IMedicoRepository> _mockMedicoRepository;

        public MedicoServiceUnitTests()
        {
            _mockMedicoRepository = new Mock<IMedicoRepository>();
            
            _service = new MedicoService(_mockMedicoRepository.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var medicos = new List<Medico>();

            _mockMedicoRepository.Setup(x => x.GetAsync()).ReturnsAsync(medicos);

            var result = await _service.GetAsync();

            Assert.NotNull(result);
        }

    }
}
