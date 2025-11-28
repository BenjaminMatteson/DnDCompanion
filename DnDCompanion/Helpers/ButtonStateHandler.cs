namespace DnDCompanion.Helpers
{
    // TODO: leave this class here for now, but current paradigm is just use popups for loading indicators
    public static class ButtonStateHandler
    {
        public static async Task HandleButtonLoading(Button button, Func<Task> operation)
        {
            if (button is null || operation is null) return;
            var originalText = button.Text;
            var originalImage = button.ImageSource;
            var orignalMaxHeight = button.MaximumHeightRequest;
            try
            {
                button.IsEnabled = false;
                button.Text = string.Empty;
                // Use ImageSource.FromFile for a local asset (Resources/Images/hourglass.gif).
                button.ImageSource = ImageSource.FromFile("hourglass.gif");
                button.MaximumHeightRequest = button.Height;
                await operation().ConfigureAwait(false);
            }
            finally
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    button.Text = originalText;
                    button.ImageSource = originalImage;
                    button.MaximumHeightRequest = orignalMaxHeight;
                    button.IsEnabled = true;
                }).ConfigureAwait(false);
            }
        }
    }
}
