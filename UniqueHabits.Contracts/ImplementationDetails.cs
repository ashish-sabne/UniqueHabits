namespace UniqueHabits.Contracts
{
    public class ImplementationDetails
    {
        public ImplementationDetails()
        {
            
        }
        public ImplementationDetails(string how, string withWhat, string when, string where, string withWhom)
        {
            How = how;
            WithWhat = withWhat;
            When = when;
            Where = where;
            WithWhom = withWhom;
        }

        public string How { get; set; }
        public string WithWhat { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string WithWhom { get; set; }
        public List<string> Steps { get; set; } = new();
    }
}
