using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueHabits.Domain.Aggregates
{
    public class ImplementationStep
    {
        public ImplementationStep() { }
        public Guid Id { get; set; }
        public string Step { get; set; }
    }
}
