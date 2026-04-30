namespace UniqueHabits.Shared.Helpers
{
    public static class GuidHelpers
    {
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return guid == null || guid.GetValueOrDefault() == Guid.Empty;
        }
        
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
}
