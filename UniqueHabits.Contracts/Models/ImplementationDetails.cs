namespace UniqueHabits.Contracts.Models
{
    public class ImplementationDetails
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string WithWhat { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string WithWhom { get; set; }
        public List<ImplementationStep> Steps { get; set; } = new();
    }
}
