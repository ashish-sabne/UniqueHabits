using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueHabits.Domain.Aggregates
{
    public partial class Habit
    {
        public Implementation LatestImplementation => Implementations.OrderByDescending(i => i.CreatedDate).FirstOrDefault();

        public Guid PreviousImplementationId => LatestImplementation?.Id ?? Guid.Empty;
        public string When => LatestImplementation?.When ?? string.Empty;
        public string Where => LatestImplementation?.Where ?? string.Empty;
        public string WithWhat => LatestImplementation?.WithWhat ?? string.Empty;
        public string WithWhom => LatestImplementation?.WithWhom ?? string.Empty;
        [NotMapped]
        public virtual List<ImplementationStep> Steps => LatestImplementation?.Steps?.OrderBy(s => s.Sequence)?.ToList() ?? new();
        public DateTime LastImplementationDate => LatestImplementation?.CreatedDate ?? DateTime.Today;
    }
}
