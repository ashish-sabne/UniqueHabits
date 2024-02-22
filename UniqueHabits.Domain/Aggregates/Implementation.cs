namespace UniqueHabits.Domain.Aggregates
{
    public class Implementation
    {
        protected Implementation() {}

        private Implementation(Guid id, Guid habitId, string withWhat, string when, string where, string withWhom, List<ImplementationStep> steps)
        {
            Id = id;
            HabitId = habitId;
            WithWhat = withWhat;
            When = when;
            Where = where;
            WithWhom = withWhom;
            CreatedDate = DateTime.Now;

            Steps = new();
            Steps = steps;
        }



        public Guid Id { get; private set; }
        public Guid HabitId { get; private set; }
        public string WithWhat { get; private set; }
        public string When { get; private set; }
        public string Where { get; private set; }
        public string WithWhom { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public Guid? PreviousImplementationId { get; private set; }
        public virtual Implementation PreviousImplementation { get; private set; }
        public string? Result { get; private set; }
        public string? CustomizationDescription { get; private set; }

        public virtual List<ImplementationStep> Steps { get; private set; } = new();

        public static Implementation Create(Guid id, Guid habitId, string withWhat, string when, string where, string withWhom, List<ImplementationStep> steps)
        {
            return new Implementation(id, habitId, withWhat, when, where, withWhom, steps);
        }
    }
}
