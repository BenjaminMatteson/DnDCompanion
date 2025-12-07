using DnDCompanion.Models;
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
        //TODO: Consider error handling strategy (e.g., logging)
        private async void OnSpellSelected(object? sender, SelectionChangedEventArgs e)
        {
            try
            {
                _vm.IsGettingSpellDetails = true;
                if (e.CurrentSelection.FirstOrDefault() is SpellListItem selectedSpell)
                {
                    if (IPlatformApplication.Current == null)
                    {
                        //TODO: Logging
                        await DisplayAlertAsync("Error", "Platform services are not available.", "OK");
                        return;
                    }

                    var serviceProvider = IPlatformApplication.Current.Services;
                    var detailsPage = serviceProvider.GetService<SpellDetailsPage>();

                    if (detailsPage != null && detailsPage.BindingContext is SpellDetailsViewModel viewModel)
                    {
                        viewModel.Initialize(selectedSpell.Index);
                        await Shell.Current.Navigation.PushAsync(detailsPage);
                    }
                }
            }
            finally
            {
                _vm.IsGettingSpellDetails = false;
            }
        }
    }
}