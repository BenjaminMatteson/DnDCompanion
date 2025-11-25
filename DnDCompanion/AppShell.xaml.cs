using DnDCompanion.Views.Spells;

namespace DnDCompanion
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SpellsListPage), typeof(SpellsListPage));
            Routing.RegisterRoute(nameof(SpellsDetailsPage), typeof(SpellsDetailsPage));
        }
    }
}
