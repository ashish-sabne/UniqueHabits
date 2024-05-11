namespace UniqueHabits.Shared.Helpers
{
    public static class GuidHelpers
    {
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return guid == null || guid.GetValueOrDefault() == Guid.Empty;
        }
    }
}
