namespace Medicar.Domain
{
    public class Agenda
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public DateOnly Dia { get; set; }

        public virtual ICollection<HorarioAgenda> Horarios { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
