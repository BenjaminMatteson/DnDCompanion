using DnDCompanion.ViewModels.Spells;

namespace DnDCompanion.Views.Spells;

public partial class SpellDetailsPage : ContentPage
{
    //TODO: implement dynamic title updating
    //public string TitleText
    //{
    //    get => $"Spell Details - {(BindingContext is SpellDetailsViewModel details ? details.Name : "Loading...")}";
    //}

    readonly SpellDetailsViewModel _vm;

    public SpellDetailsPage(SpellDetailsViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }

}