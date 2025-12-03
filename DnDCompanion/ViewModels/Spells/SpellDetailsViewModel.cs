using DnDCompanion.Models;
using DnDCompanion.Services;
using System.ComponentModel;

namespace DnDCompanion.ViewModels.Spells
{
    public class SpellDetailsViewModel : INotifyPropertyChanged
    {
        readonly IAPIService _apiService;
        private SpellDetails _spellDetails = new();

        public SpellDetailsViewModel(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public void Initialize(string spellIndex)
        {
            _spellDetails.Index = spellIndex;
            GetSpellDetails();
        }

        private void GetSpellDetails()
        {
            var spellDetailsResult = _apiService.GetSpellDetails(_spellDetails.Index).Result;
            _spellDetails = spellDetailsResult;
            OnPropertyChanged(string.Empty);
        }

        #region Properties

        public string Index
        {
            get => _spellDetails.Index;
            set
            {
                if (_spellDetails.Index == value) return;
                _spellDetails.Index = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _spellDetails.Name;
            set
            {
                if (_spellDetails.Name == value) return;
                _spellDetails.Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => string.Join("\n", _spellDetails.Desc);
            set
            {
                var descList = value.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (_spellDetails.Desc.SequenceEqual(descList)) return;
                _spellDetails.Desc = descList;
                OnPropertyChanged();
            }
        }

        public List<string> HigherLevel { get; set; } = new();

        public string Range
        {
            get => _spellDetails.Range;
            set
            {
                if (_spellDetails.Range == value) return;
                _spellDetails.Range = value;
                OnPropertyChanged();
            }
        }

        public List<string> Components { get; set; } = new();

        public string? Material
        {
            get => _spellDetails.Material;
            set
            {
                if (_spellDetails.Material == value) return;
                _spellDetails.Material = value;
                OnPropertyChanged();
            }
        }

        public bool Ritual
        {
            get => _spellDetails.Ritual;
            set
            {
                if (_spellDetails.Ritual == value) return;
                _spellDetails.Ritual = value;
                OnPropertyChanged();
            }
        }

        public string Duration
        {
            get => _spellDetails.Duration;
            set
            {
                if (_spellDetails.Duration == value) return;
                _spellDetails.Duration = value;
                OnPropertyChanged();
            }
        }

        public bool Concentration
        {
            get => _spellDetails.Concentration;
            set
            {
                if (_spellDetails.Concentration == value) return;
                _spellDetails.Concentration = value;
                OnPropertyChanged();
            }
        }

        public string CastingTime
        {
            get => _spellDetails.CastingTime ?? string.Empty;
            set
            {
                if (_spellDetails.CastingTime == value) return;
                _spellDetails.CastingTime = value;
                OnPropertyChanged();
            }
        }

        public int Level
        {
            get => _spellDetails.Level;
            set
            {
                if (_spellDetails.Level == value) return;
                _spellDetails.Level = value;
                OnPropertyChanged();
            }
        }

        public string? AttackType
        {
            get => _spellDetails.AttackType;
            set
            {
                if (_spellDetails.AttackType == value) return;
                _spellDetails.AttackType = value;
                OnPropertyChanged();
            }
        }

        public DamageInfo? Damage { get; set; } = new();

        public ApiReference? School { get; set; } = new();

        public List<ApiReference> Classes { get; set; } = new();

        public List<ApiReference> Subclasses { get; set; } = new();

        public string Url
        {
            get => _spellDetails.Url;
            set
            {
                if (_spellDetails.Url == value) return;
                _spellDetails.Url = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
