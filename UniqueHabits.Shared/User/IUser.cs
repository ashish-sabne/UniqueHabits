using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueHabits.Shared.User
{
    public interface IUser
    {
        Guid? Id { get; }
        string Name { get; }
        bool IsAuthenticated { get; }
    }
}
