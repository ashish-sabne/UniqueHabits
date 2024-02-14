using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueHabits.Contracts.Models
{
    public class ImplementationStep
    {
        public Guid Id { get; set; }
        public string Step { get; set; }
        public int Sequence { get; set; }
    }
}
