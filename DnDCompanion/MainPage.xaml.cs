using DnDCompanion.Views.Spells;

namespace DnDCompanion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGoToSpellsClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SpellsListPage));
        }
    }
}
