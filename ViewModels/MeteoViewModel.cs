using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_meteosuisse.Service;
using System.Diagnostics;

namespace maui_meteosuisse.ViewModels;

public partial class MeteoViewModel : BaseViewModel 
{
    readonly MeteoService _meteoService;

    [ObservableProperty]
    Models.Data meteo;

    public MeteoViewModel(MeteoService meteoService)
    {
        _meteoService = meteoService;
        IsBusy = false;
        Title = "Meteo suisse";
    }

    [RelayCommand]
    async Task GetMeteo()
    {
        if (IsNotBusy)
        {
            try
            {
                IsBusy = true;
                string version = await _meteoService.GetVersion("weather-widget/forecast");
                Meteo = await _meteoService.GetWeatherAsync(version);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get meteo: {ex.Message}", this.GetType().Name);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
