namespace Medicar.Domain.Commands.Requests
{
    public class AgendaRequest
    {

        public int MedicoCRM { get; set; }
        public DateTime Dia { get; set; }
        public List<string> Horarios { get; set; }
    }
}