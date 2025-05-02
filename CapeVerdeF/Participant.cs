namespace CapeVerdeF
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


}
