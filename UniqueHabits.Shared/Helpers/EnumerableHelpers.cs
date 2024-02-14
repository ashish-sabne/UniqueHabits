using System.Collections;

namespace UniqueHabits.Shared.Helpers
{
    public static class EnumerableHelpers
    {
        public static bool IsAny<T>(this IEnumerable<T> values) 
        { 
            return values != null && values.Any(); 
        }
    }
}
