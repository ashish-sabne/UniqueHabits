using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Contracts.Models
{
    public class NotificationModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateNotified { get; set; }
        public bool IsRead { get; set; }
        public Guid HabitId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string DurationSince { get; set; }
    }
}
