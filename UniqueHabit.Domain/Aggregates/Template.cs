namespace UniqueHabit.Domain.Aggregates
{
    public class Template
    {
        public Template() {}
        private Template(Guid id, string systemName, DateTime startDate, TemplateCategory category)
        {
            Id = id;
            SystemName = systemName;
            StartDate = startDate;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string SystemName { get; private set; }
        public DateTime StartDate { get; private set; }
        public TemplateCategory Category { get; private set; }

        public static Template Create(Guid id, string systemName, DateTime startDate, TemplateCategory category)
        {
            return new Template(id, systemName, startDate, category);
        }
    }
}
