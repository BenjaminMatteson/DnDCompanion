using DnDCompanion.ViewModels.Spells;

namespace DnDCompanion.Views.Spells
{
    public partial class SpellsListPage : ContentPage
    {
        readonly SpellsListViewModel vm;

        public SpellsListPage()
        {
            InitializeComponent();
            vm = new SpellsListViewModel();
            BindingContext = vm;
        }

        private async void OnGetSpellsClicked(object? sender, EventArgs e)
        {
            // Ensure sender is a Button and pass a Func<Task> as required by HandleButtonLoading
            if (sender is Button button)
            {
                //TODO: Move APIService instantiation to DI container
                var apiService = new APIService();
                try
                {
                    vm.IsGettingSpells = true;
                    var spells = await apiService.GetSpellsList();
                    SpellsCollectionView.ItemsSource = spells;
                }
                catch (Exception ex)
                {
                    await DisplayAlertAsync("Error", $"Failed to load spells: {ex.Message}", "OK");
                }
                finally
                {
                    vm.IsGettingSpells = false;
                }
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
            try
            {
                vm.IsGettingSpellDetails = true;
                if (e.CurrentSelection.FirstOrDefault() is Classes.SpellListItem selectedSpell)
                {
                    // Navigate and pass index via query string
                    var route = $"{nameof(SpellsDetailsPage)}?index={Uri.EscapeDataString(selectedSpell.Index)}";
                    await Shell.Current.GoToAsync(route);
                }
            }
            finally
            {
                vm.IsGettingSpellDetails = false;
            }
        }
    }
}