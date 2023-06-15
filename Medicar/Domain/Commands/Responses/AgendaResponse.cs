namespace Medicar.Domain.Commands.Responses
{
    public class AgendaResponse
    {
        public int Id { get; set; }
        public Medico Medico { get; set; }
        public DateOnly Dia { get; set; }
        public List<string> Horarios { get; set; }
    }
}