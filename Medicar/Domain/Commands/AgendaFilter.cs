namespace Medicar.Domain.Views
{
    public class AgendaFilter
    {
        public List<int>? MedicoIds { get; set; }
        public List<int>? MedicoCRMs { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
