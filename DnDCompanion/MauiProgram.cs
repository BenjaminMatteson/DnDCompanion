using Microsoft.Extensions.Logging;

namespace DnDCompanion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services for dependency injection
            builder.Services.AddSingleton<Services.IAPIService, Services.APIService>();

            // Register ViewModels for dependency injection
            builder.Services.AddTransient<ViewModels.Spells.SpellsListViewModel>();

            // Register Views for dependency injection
            builder.Services.AddTransient<Views.Spells.SpellsListPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
