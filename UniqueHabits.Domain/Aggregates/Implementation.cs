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



        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public string WithWhat { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string WithWhom { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual List<ImplementationStep> Steps { get; set; } = new();

        public static Implementation Create(Guid id, Guid habitId, string withWhat, string when, string where, string withWhom, List<ImplementationStep> steps)
        {
            return new Implementation(id, habitId, withWhat, when, where, withWhom, steps);
        }
    }
}
