using System;
using System.Collections.Generic;
using System.Linq;

namespace CapeVerdeCulturalFestival
{
    public class FestivalManager
    {
        public string Name { get; } = "Cape Verdean-American Festival";
        public int Year { get; } = DateTime.Now.Year;
        public List<Participant> Participants { get; } = new List<Participant>();

        public bool RegisterParticipant(Participant participant)
        {
            ValidateCulturalRules(participant);
            Participants.Add(participant);
            return true;
        }

        private void ValidateCulturalRules(Participant p)
        {
            if (p is FunanaDanceParticipant funana && funana.DancerCount < 2)
                throw new ArgumentException("Funana requires at least 2 dancers!");

            if (p.Category == "Cachupa Cooking" && string.IsNullOrWhiteSpace(p.Contact))
                throw new ArgumentException("Chefs must provide contact info!");
        }

        public string GetCulturalStats()
        {
            return $@"Cultural Breakdown:
Morna: {Participants.OfType<MornaParticipant>().Count()} groups
Funana: {Participants.OfType<FunanaDanceParticipant>().Count()} troupes
Batuque: {Participants.Count(p => p.Category == "Batuque Performance")} circles";
        }

        public decimal GetTotalFees() => Participants.Sum(p => p.FeePaid);
    }
}
        public decimal GetTotalFees() => Participants.Sum(p => p.FeePaid);
    }
}
