using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DnDCompanion.ViewModels.Spells
{
    public class SpellsListViewModel : INotifyPropertyChanged
    {
        bool isGettingSpells;
        public bool IsGettingSpells
        {
            get => isGettingSpells;
            set
            {
                if (isGettingSpells == value) return;
                isGettingSpells = value;
                OnPropertyChanged();
            }
        }

        bool isGettingSpellDetails;
        public bool IsGettingSpellDetails
        {
            get => isGettingSpellDetails;
            set
            {
                if (isGettingSpellDetails == value) return;
                isGettingSpellDetails = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}