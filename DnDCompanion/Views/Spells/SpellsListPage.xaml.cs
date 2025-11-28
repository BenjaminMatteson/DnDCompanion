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

        private async void OnSpellSelected(object? sender, SelectionChangedEventArgs e)
        {
            try
            {
                vm.IsGettingSpellDetails = true;
                if (e.CurrentSelection.FirstOrDefault() is Classes.SpellListItem selectedSpell)
                {
                    // TODO: remove thise delay and implement actual API call to get spell details
                    // Mimic an API call with a 10 second delay
                    await Task.Delay(10000);

                    // Handle spell selection (e.g., navigate to spell details page)
                    await Shell.Current.GoToAsync(nameof(SpellsDetailsPage));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to load spell: {ex.Message}", "OK");
            }
            finally
            {
                vm.IsGettingSpellDetails = false;
            }

        }
    }
}