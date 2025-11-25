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
            // Create an instance of the API service
            var apiService = new APIService();
            try
            {
                // Fetch the spells list
                var spells = await apiService.GetSpellsList();
                // Display the spells in the ListView
                SpellsCollectionView.ItemsSource = spells;
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the API call
                await DisplayAlertAsync("Error", $"Failed to load spells: {ex.Message}", "OK");
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