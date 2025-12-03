using DnDCompanion.Models;
using DnDCompanion.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DnDCompanion.ViewModels.Spells
{
    public class SpellsListViewModel : INotifyPropertyChanged
    {
        readonly IAPIService _apiService;

        #region Properties
        private bool _isGettingSpells;
        public bool IsGettingSpells
        {
            get => _isGettingSpells;
            set
            {
                if (_isGettingSpells == value) return;
                _isGettingSpells = value;
                OnPropertyChanged();
            }
        }

        private bool _isGettingSpellDetails;
        public bool IsGettingSpellDetails
        {
            get => _isGettingSpellDetails;
            set
            {
                if (_isGettingSpellDetails == value) return;
                _isGettingSpellDetails = value;
                OnPropertyChanged();
            }
        }

        private IList<SpellListItem> _spells = new List<SpellListItem>();
        public IList<SpellListItem> Spells
        {
            get => _spells;
            set
            {
                if (_spells == value) return;
                _spells = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public SpellsListViewModel(IAPIService apiService) 
        {
            _apiService = apiService;
        } 

        public async Task GetSpellsAsync()
        {
            try
            {
                IsGettingSpellDetails = true;
                var spellsResults = await _apiService.GetSpellsList();
                Spells = spellsResults.ToList();
            }
            finally
            {
                IsGettingSpellDetails = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}