using DnDCompanion.Classes;
using System.ComponentModel;

namespace DnDCompanion.ViewModels.Spells
{
    public class SpellDetailsViewModel
    {
        public SpellDetailsViewModel() 
        {
            Type = "SpellDetailsViewModel";
        }

        public SpellDetailsViewModel(SpellDetails spellDetails) 
        {
            if (spellDetails == null)
            {
                throw new ArgumentNullException(nameof(spellDetails));
            }

            Index = spellDetails.Index;
            Name = spellDetails.Name;
            Description = string.Join("\n", spellDetails.Desc);
            HigherLevel = spellDetails.HigherLevel;
            Range = spellDetails.Range;
            Components = spellDetails.Components;
            Material = spellDetails.Material;
            Ritual = spellDetails.Ritual;
            Duration = spellDetails.Duration;
            Concentration = spellDetails.Concentration;
            CastingTime = spellDetails.CastingTime;
            Level = spellDetails.Level;
            AttackType = spellDetails.AttackType;
            Damage = spellDetails.Damage;
            School = spellDetails.School;
            Classes = spellDetails.Classes;
            Subclasses = spellDetails.Subclasses;
            Url = spellDetails.Url;
            Type = "SpellDetailsViewModel";
        }

        public string Index { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> HigherLevel { get; set; } = new();
        public string Range { get; set; } = string.Empty;
        public List<string> Components { get; set; } = new();
        public string? Material { get; set; }
        public bool Ritual { get; set; }
        public string Duration { get; set; } = string.Empty;
        public bool Concentration { get; set; }
        public string CastingTime { get; set; } = string.Empty;
        public int Level { get; set; }
        public string? AttackType { get; set; }
        public DamageInfo? Damage { get; set; }
        public ApiReference? School { get; set; }
        public List<ApiReference> Classes { get; set; } = new();
        public List<ApiReference> Subclasses { get; set; } = new();
        public string Url { get; set; } = string.Empty;
        public string Type { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
