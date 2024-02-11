using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Contracts
{
    public class HabitModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SystemName { get; set; }
        public string MeasurableResult { get; set; }
        public string? Why { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public HabitCategory? Category { get; set; }
        public string? CategoryDescription { get; set; }

        public ImplementationDetails ImplementationDetails { get; set; } = new ImplementationDetails();

    }
}