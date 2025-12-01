using DnDCompanion.ViewModels.Spells;

namespace DnDCompanion.Views.Spells;

[QueryProperty(nameof(Index), "index")]
public partial class SpellsDetailsPage : ContentPage
{
    public string Index
    {
        set => _ = LoadDetailsAsync(value);
    }

    public string TitleText
    {
        get => $"Spell Details - {(BindingContext is Classes.SpellDetails details ? details.Name : "Loading...")}";
    }
    public SpellsDetailsPage()
    {
        InitializeComponent();

        // assign view model instance as BindingContext
        BindingContext = new SpellDetailsViewModel();
    }

    //TODO: Handle cancellation token
    //TODO: This feels like it could be moved to the ViewModel
    async Task LoadDetailsAsync(string index)
    {
        try
        {
            //TODO: APIService should be injected via DI
            var apiService = new APIService();
            var spellDetailsResponse = await apiService.GetSpellDetails(index);
            if (spellDetailsResponse == null)
            {
                await DisplayAlertAsync("Error", "Spell details not found.", "OK");
                return;
            }

            BindingContext = spellDetailsResponse;
        }
            catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Failed to load spell details: {ex.Message}", "OK");
        }
    }
}