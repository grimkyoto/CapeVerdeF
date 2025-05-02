namespace CapeVerdeCulturalFestival
{
    public class Participant
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Contact { get; set; }
        public decimal FeePaid { get; protected set; }
        public bool IsValid { get; set; }

        public Participant(string name, string category, string contact)
        {
            Name = name;
            Category = category;
            Contact = contact;
            CalculateFee();
        }

        protected virtual void CalculateFee()
        {
            FeePaid = 25.00m; // Base fee
        }

        public virtual string GetDisplayInfo() => $"{Name} ({Category})";
    }

    public class MornaParticipant : Participant
    {
        public bool IsTraditional { get; set; }
        public string Instrument { get; set; }

        public MornaParticipant(string name, string contact, bool isTraditional, string instrument) 
            : base(name, "Morna Music", contact)
        {
            IsTraditional = isTraditional;
            Instrument = instrument;
        }

        protected override void CalculateFee()
        {
            FeePaid = IsTraditional ? 20.00m : 30.00m;
        }

        public override string GetDisplayInfo() => 
            $"{Name} - {Instrument} Morna ({(IsTraditional ? "Traditional" : "Modern")})";
    }

    public class FunanaDanceParticipant : Participant
    {
        public int DancerCount { get; set; }

        public FunanaDanceParticipant(string name, string contact, int dancerCount) 
            : base(name, "Funana Dance", contact)
        {
            DancerCount = dancerCount;
        }

        protected override void CalculateFee()
        {
            FeePaid = 15.00m * DancerCount;
        }

        public override string GetDisplayInfo() => 
            $"{Name} - Funana Group ({DancerCount} dancers)";
    }
}
