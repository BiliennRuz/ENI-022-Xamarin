namespace MyTPMeteo
{
    using MyTPMeteo.DependencyService;
    using MyTPMeteo.Service;
    using MyTPMeteo.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Météo 2";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            // vérification de la saisie d'une ville
            if(String.IsNullOrEmpty(EntryCity.Text))
            {
                await DisplayAlert("Erreur", "Vous devez renseigner une ville", "OK");
                return;
            }

            // vérification de la connexion 
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Erreur", "Vous devez être connecté", "OK");
                return;
            }

            // gestion API
            var owm = new OWMService();
            var apiWeather = await owm.CurrentWeather(EntryCity.Text);

            if(apiWeather.Cod == 200) // réponse valide
            {
                LabelCity.Text = apiWeather.Name;
                LabelTemperature.Text = apiWeather.Temperature.Temp.ToString() + "°C";
                String UrlIcone = String.Format(Constant.URL_ICON, apiWeather.Weathers[0].Icon);
                ImageIcon.Source = UrlIcone;
                    // TODO : afficher le nom de la ville LabelCity
                // TODO : afficher la température dans LabelTemperature
                // TODO : afficher l'image du temps dans ImageIcon
            }
            else
            {
                // erreur 
                await DisplayAlert("Erreur", apiWeather.Message, "OK");
                Xamarin.Forms.DependencyService.Get<ToastInterface>().toast(apiWeather.Message);
            }

        }

    }
}
