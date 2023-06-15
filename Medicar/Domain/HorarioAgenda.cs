namespace Medicar.Domain
{
    public class HorarioAgenda
    {
        public int Id { get; set; }
        public TimeOnly Horario { get; set; }
        public int AgendaId { get; set; }

        public virtual Agenda Agenda { get; set; }
    }
}