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
            builder.Services.AddTransient<ViewModels.Spells.SpellDetailsViewModel>();

            // Register Views for dependency injection
            builder.Services.AddTransient<Views.Spells.SpellsListPage>();
            builder.Services.AddTransient<Views.Spells.SpellDetailsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
