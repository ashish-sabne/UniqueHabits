using System.ComponentModel.DataAnnotations;

namespace UniqueHabits.UI.Models
{
    public class HabitModel
    {
        public Guid HabitId { get; set; } = Guid.NewGuid();
        [Required]
        public string What { get; set; }
        public string Why { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [Required]
        public HabitCategory? Category { get; set; }

    }
}
