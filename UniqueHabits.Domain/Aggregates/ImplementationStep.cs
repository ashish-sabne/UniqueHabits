namespace UniqueHabits.Domain.Aggregates
{
    public class ImplementationStep
    {
        public ImplementationStep() { }
        public Guid Id { get; set; }
        public string Step { get; set; }
        public int Sequence { get; set; }
    }
}
