using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Contracts.Models
{
    public class HabitReviewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SystemName { get; set; }
        public string MeasurableResult { get; set; }
        public string? Why { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public HabitCategory? Category { get; set; }
        public string? CategoryDescription { get; set; }

        public DateTime LastImplementationDate { get; set; }
        public string? Result { get; set; }
        public string? CustomizationDescription { get; set; }

        public CustomizationCategory CustomizationCategory { get; set; }

    }
}