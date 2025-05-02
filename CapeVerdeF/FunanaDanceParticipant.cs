using System;

namespace CapeVerdeF
{
    public class FunanaDanceParticipant : Participant
    {
        // funana properties
        public int DancerCount { get; set; }
        public bool UsesFerrinho { get; set; } 
        public string AccordionType { get; set; }

        public FunanaDanceParticipant(string name, string contact, 
                                    int dancerCount, bool usesFerrinho)
            : base(name, "Funana Dance", contact)
        {
            if (dancerCount < 2)
                throw new ArgumentException("Funana requires at least 2 dancers!");

            DancerCount = dancerCount;
            UsesFerrinho = usesFerrinho;
            AccordionType = "Diatonic"; 
            CalculateFee();
        }

        protected override void CalculateFee()
        {
            
            FeePaid = 40.00m + (15.00m * DancerCount);
            
            // trad performer discount
            if (UsesFerrinho) FeePaid *= 0.9m; // 10% 
        }

        public override string GetDisplayInfo()
        {
            string ferrinho = UsesFerrinho ? "with Ferrinho" : "";
            return $"{Name} 💃 Funana Group ({DancerCount} dancers) {ferrinho}";
        }

        
        public string GetRecommendedStageSize()
        {
            return DancerCount switch
            {
                < 4 => "Small (5x5m)",
                < 8 => "Medium (8x8m)",
                _ => "Large (10x10m)"
            };
        }
    }
}