namespace UniqueHabits.Contracts
{
    public class ImplementationDetails
    {
        public ImplementationDetails()
        {
            
        }
        public ImplementationDetails(string withWhat, string when, string where, string withWhom)
        {
            WithWhat = withWhat;
            When = when;
            Where = where;
            WithWhom = withWhom;
        }

        public string WithWhat { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string WithWhom { get; set; }
        public List<ImplementationStep> Steps { get; set; } = new();
    }
}
