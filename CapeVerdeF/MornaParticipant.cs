using System;
using System.Drawing; 

namespace CapeVerdeF
{
    public class MornaParticipant : Participant
    {
        // morna properties
        public string Instrument { get; set; }
        public bool IsTraditional { get; set; }
        public string VocalStyle { get; set; } 
        public Color CostumeColor { get; set; } 

        public MornaParticipant(string name, string contact, 
                              string instrument, bool isTraditional)
            : base(name, "Morna Music", contact)
        {
            Instrument = instrument;
            IsTraditional = isTraditional;
            VocalStyle = "Sodade";
            CostumeColor = isTraditional ? Color.FromArgb(0, 61, 121) : Color.Gold;
            CalculateFee();
        }

        protected override void CalculateFee()
        {
            // performer discount
            FeePaid = IsTraditional ? 20.00m : 35.00m;
        }

        public override string GetDisplayInfo()
        {
            string traditionTag = IsTraditional ? "[Traditional]" : "[Modern]";
            return $"{Name} 🎶 {Instrument} Morna {traditionTag} ({VocalStyle})";
        }

        
        public string GetMusicalScale()
        {
            return IsTraditional ? "Minor Pentatonic" : "Contemporary Scale";
        }
    }
}