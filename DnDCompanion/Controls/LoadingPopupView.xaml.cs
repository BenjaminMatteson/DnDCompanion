using Microsoft.Maui.Controls;

namespace DnDCompanion.Controls
{
    public partial class LoadingPopupView : ContentView
    {
        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(
                nameof(Message),
                typeof(string),
                typeof(LoadingPopupView),
                default(string));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public LoadingPopupView()
        {
            InitializeComponent();
        }
    }
}