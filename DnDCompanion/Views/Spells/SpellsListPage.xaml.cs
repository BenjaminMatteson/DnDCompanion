using DnDCompanion.Helpers;

namespace DnDCompanion.Views.Spells
{
    public partial class SpellsListPage : ContentPage
    {
        public SpellsListPage()
        {
            InitializeComponent();
        }

        private async void OnGetSpellsClicked(object? sender, EventArgs e)
        {
            // Ensure sender is a Button and pass a Func<Task> as required by HandleButtonLoading
            if (sender is Button button)
            {
                await ButtonStateHandler.HandleButtonLoading(button, async () =>
                {
                    //TODO: Move APIService instantiation to DI container
                    var apiService = new APIService();
                    try
                    {
                        var spells = await apiService.GetSpellsList();
                        SpellsCollectionView.ItemsSource = spells;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlertAsync("Error", $"Failed to load spells: {ex.Message}", "OK");
                    }
                });
            }
        }

        private async void OnBackClicked(object? sender, EventArgs e)
        {
            // Navigate back using Shell
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSpellSelected(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Classes.SpellListItem selectedSpell)
            {
                // Handle spell selection (e.g., navigate to spell details page)
                await Shell.Current.GoToAsync(nameof(SpellsDetailsPage));
            }
        }
    }
}