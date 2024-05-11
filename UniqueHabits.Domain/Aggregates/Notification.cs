using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Domain.Aggregates
{
    public class Notification
    {
        protected Notification() { }

        private Notification(Guid id, string title, DateTime dateNotified, Guid habitId, string createdById, 
            NotificationType notificationType)
        {
            Id = id;
            Title = title;
            DateNotified = dateNotified;
            IsRead = false;
            HabitId = habitId;
            CreatedById = createdById;
            NotificationType = notificationType;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime DateNotified { get; private set; }
        public bool IsRead { get; private set; } = false;
        public Guid HabitId { get; private set; }
        public virtual Habit Habit { get; private set; }
        public string CreatedById { get; private set; }
        public virtual AppUser CreatedBy { get; private set; }
        public NotificationType NotificationType { get; private set; }

        public string DurationSince
        {
            get
            {
                var diff = DateTime.Today - DateNotified;

                if (diff.Days > 1)
                {
                    return $"{diff.Days} days ago";
                }
                else if (diff.Days > 0)
                {
                    return $"Today";
                }
                return string.Empty;
            }
        }

        public static Notification Create(Guid id, string title, DateTime dateNotified, Guid habitId, Guid createdById,
            NotificationType notificationType)
        {
            return new Notification(id, title, dateNotified, habitId, createdById.ToString(), notificationType);
        }
    }
}
