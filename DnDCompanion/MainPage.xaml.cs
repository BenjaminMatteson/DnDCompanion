namespace DnDCompanion
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnGoToSpellsClicked(object? sender, EventArgs e)
        {
            // Register the route to the page path (idempotent)
            try
            {
                Routing.RegisterRoute("Views/Spells/SpellsListPage", typeof(Views.Spells.SpellsListPage));
            }
            catch (ArgumentException)
            {
                // Route already registered - ignore
            }

            // Navigate using the registered route (absolute)
            await Shell.Current.GoToAsync("Views/Spells/SpellsListPage");
        }
    }
}
