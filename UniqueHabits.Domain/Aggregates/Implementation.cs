namespace UniqueHabits.Domain.Aggregates
{
    public class Implementation
    {
        public Implementation()
        {
        }

        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public virtual List<ImplementationStep> Steps { get; set; } = new();
        public string WithWhat { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string WithWhom { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
