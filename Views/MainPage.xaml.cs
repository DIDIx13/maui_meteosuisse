namespace maui_meteosuisse.Views;

using maui_meteosuisse.ViewModels;
using System.ComponentModel;

public partial class MainPage : ContentPage
{
	MeteoViewModel meteoViewModel;
    Animation animate0To360;
    public MainPage(MeteoViewModel meteoViewModel)
    {
        InitializeComponent();
        this.meteoViewModel = meteoViewModel;
        BindingContext = meteoViewModel;

        animate0To360 = new Animation((animationValue) => LabelLoad.Rotation = animationValue, 0, 360, Easing.Linear);
        meteoViewModel.PropertyChanged += MeteoViewModel_PropertyChanged;
    }

    private void MeteoViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(meteoViewModel.IsBusy))
        {
            if (meteoViewModel.IsBusy)
            {
                // Si le modèle est occupé, on démarre l'animation
                animate0To360.Commit(
                    this,
                    "rotate",
                    16,
                    1000,
                    Easing.Linear,
                    (a, b) => LabelLoad.Rotation = 0,
                    () => true
                    );
            }
            else
            {
                this.AbortAnimation("rotate");
            }
        }
    }
}

