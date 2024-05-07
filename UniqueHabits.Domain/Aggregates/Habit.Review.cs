using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueHabits.Shared.Enums;

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

        public Implementation AddReview(string result, string customizationDescription, CustomizationCategory customizationCategory, string when, string where, 
            string withWhat, string withWhom, List<ImplementationStep> steps)
        {
            var stepsCopy = Steps.Select(s => ImplementationStep.Create(Guid.NewGuid(), s.Step, s.Sequence)).ToList();
            var newImplementation = Implementation.Create(Guid.NewGuid(), Id, PreviousImplementationId, result, customizationDescription, 
                customizationCategory, WithWhat, When, Where, WithWhom, stepsCopy);

            switch (customizationCategory)
            {
                case CustomizationCategory.WithWhat:
                    newImplementation.UpdateWithWhat(withWhat);
                    break;
                case CustomizationCategory.When:
                    newImplementation.UpdateWhen(when);
                    break;
                case CustomizationCategory.Where:
                    newImplementation.UpdateWhere(where);
                    break;
                case CustomizationCategory.WithWhom:
                    newImplementation.UpdateWithWhom(withWhom);
                    break;
                case CustomizationCategory.How:
                    newImplementation.UpdateSteps(steps);
                    break;
                default:
                    break;
            }
            return newImplementation;
        }
    }
}
