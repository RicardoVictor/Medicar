namespace Medicar.Domain.Commands.Responses
{
    public class ConsultaResponse
    {
        public int Id { get; set; }
        public DateOnly Dia { get; set; }
        public string Horario { get; set; }
        public DateTime DataAgendamento { get; set; }
        public Medico Medico { get; set; }
    }
}