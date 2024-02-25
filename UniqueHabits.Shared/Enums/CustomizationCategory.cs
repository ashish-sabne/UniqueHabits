using System.ComponentModel;

namespace UniqueHabits.Shared.Enums
{
    public enum CustomizationCategory
    {
        [Description("No Change")]
        NoChange,
        [Description("With What - Improve a tool")]
        WithWhat,
        [Description("When - Adjust the schedule")]
        When,
        [Description("Where - Change the environment")]
        Where,
        [Description("With whom – Modify a partnership")]
        WithWhom,
        [Description("How – Alter one system step")]
        How,
    }
}
