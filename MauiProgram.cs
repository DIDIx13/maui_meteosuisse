using maui_meteosuisse.Service;
using maui_meteosuisse.ViewModels;
using maui_meteosuisse.Views;

namespace maui_meteosuisse;

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

                fonts.AddFont("fa-brands-400.otf", "FAB");
                fonts.AddFont("fa-regular-400.otf", "FAR");
                fonts.AddFont("fa-solid-900.otf", "FAS");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MeteoService>();
		builder.Services.AddSingleton<MeteoViewModel>();

        return builder.Build();
	}
}
