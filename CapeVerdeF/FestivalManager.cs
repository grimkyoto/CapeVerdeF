using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CapeVerdeF
{
    public class FestivalManager
    {
        public string ManagerName { get; set; } = "Your Name";
        public string FestivalName { get; } = "Cape Verdean-American Cultural Festival";
        public int Year { get; } = DateTime.Now.Year;
        public List<Participant> Participants { get; set; } = new List<Participant>();

        public Dictionary<string, int> GetCategoryCounts()
        {
            return new Dictionary<string, int>
            {
                {"Morna Music", Participants.Count(p => p.Category.Contains("Morna"))},
                {"Funana Dance", Participants.Count(p => p.Category.Contains("Funana"))},
                {"Batuque Performance", Participants.Count(p => p.Category.Contains("Batuque"))},
                {"Cachupa Cooking", Participants.Count(p => p.Category.Contains("Cachupa"))}
            };
        }
        public bool RegisterParticipant(Participant participant)
{
    if (ValidateParticipant(participant))
    {
        Participants.Add(participant);
        return true;
    }
    return false;
}

        public string GetCulturalStats()
{
    var counts = GetCategoryCounts();
    return $"Morna: {counts["Morna Music"]} | Funana: {counts["Funana Dance"]}";
}

        public decimal GetTotalFees()
{
    return Participants.Sum(p => p.FeePaid);
}
        public bool ValidateParticipant(Participant p)
        {
            if (p.Category == "Funana Dance" && !p.Name.Contains("Group"))
            {
                throw new ArgumentException("Funana requires group registration!");
            }
            
            if (p.Category == "Cachupa Cooking" && string.IsNullOrEmpty(p.Contact))
            {
                throw new ArgumentException("Chefs must provide contact info!");
            }
            return true;
        }

        public Participant FindParticipant(string name)
        {
            return Participants.FirstOrDefault(p => 
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ExportToCSV(string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine($"Cape Verdean Festival,{Year},Managed by: {ManagerName}");
            csv.AppendLine("Name,Category,Contact,Fee,Special Attributes");
            
            foreach (var p in Participants)
            {
                string specialAttributes = p switch
                {
                    MornaParticipant m => $"Instrument: {m.Instrument}, Traditional: {m.IsTraditional}",
                    FunanaDanceParticipant f => $"Dancers: {f.DancerCount}",
                    _ => "General Participant"
                };
                
                csv.AppendLine($"\"{p.Name}\",{p.Category},{p.Contact},{p.FeePaid},\"{specialAttributes}\"");
            }
            
            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        }
    }
}