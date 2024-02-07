namespace UniqueHabits.Domain.Aggregates
{
    public class ImplementationStep
    {
        protected ImplementationStep() { }

        private ImplementationStep(Guid id, string step, int sequence)
        {
            Id = id;
            Step = step;
            Sequence = sequence;
        }

        public Guid Id { get; set; }
        public string Step { get; set; }
        public int Sequence { get; set; }

        public static ImplementationStep Create(Guid id, string step, int sequence)
        {
            return new ImplementationStep(id, step, sequence);
        }
    }
}
