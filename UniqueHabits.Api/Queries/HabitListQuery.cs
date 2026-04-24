using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Api.Queries
{
    public class HabitListQuery : IRequest<List<HabitModel>>
    {
    }
}
