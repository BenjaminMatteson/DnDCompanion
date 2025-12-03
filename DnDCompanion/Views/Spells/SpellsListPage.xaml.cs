using DnDCompanion.ViewModels.Spells;

namespace DnDCompanion.Views.Spells
{
    public partial class SpellsListPage : ContentPage
    {
        readonly SpellsListViewModel _vm;

        public SpellsListPage(SpellsListViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        private async void OnGetSpellsClicked(object? sender, EventArgs e)
        {
            try
            {
                await _vm.GetSpellsAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to load spells: {ex.Message}", "OK");
            }
        }

        private async void OnBackClicked(object? sender, EventArgs e)
        {
            // Navigate back using Shell
            await Shell.Current.GoToAsync("..");
        }

        //TODO: Consider moving navigation logic to a NavigationService
        //TODO: Move APIService instantiation to DI container
        //TODO: Move JSON options to a shared location if used elsewhere
        //TODO: Consider error handling strategy (e.g., logging)
        //TODO: Consider using a command in the ViewModel instead of code-behind
        private async void OnSpellSelected(object? sender, SelectionChangedEventArgs e)
        {
            return;

            //try
            //{
            //    vm.IsGettingSpellDetails = true;
            //    if (e.CurrentSelection.FirstOrDefault() is Classes.SpellListItem selectedSpell)
            //    {
            //        // Navigate and pass index via query string
            //        var route = $"{nameof(SpellsDetailsPage)}?index={Uri.EscapeDataString(selectedSpell.Index)}";
            //        await Shell.Current.GoToAsync(route);
            //    }
            //}
            //finally
            //{
            //    vm.IsGettingSpellDetails = false;
            //}
        }
    }
}