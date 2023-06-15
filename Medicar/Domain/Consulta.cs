namespace Medicar.Domain
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateOnly Dia { get; set; }
        public TimeOnly Horario { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int MedicoId { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
