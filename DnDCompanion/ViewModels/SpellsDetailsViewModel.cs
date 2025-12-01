using System.ComponentModel;

namespace DnDCompanion.ViewModels
{
    public class SpellsDetailsViewModel : INotifyPropertyChanged
    {
        private string _titleText = "Default title";

        public string TitleText
        {
            get => _titleText;
            set
            {
                if (_titleText == value) return;
                _titleText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleText)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}