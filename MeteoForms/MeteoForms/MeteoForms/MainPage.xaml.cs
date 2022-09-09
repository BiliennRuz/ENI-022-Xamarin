namespace MeteoForms
{
    using MeteoForms.DependencyService;
    using MeteoForms.Service;
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
                // TODO : afficher le nom de la ville LabelCity
                // TODO : afficher la température dans LabelTemperature
                // TODO : afficher l'image du temps dans ImageIcon
            }
            else
            {
                // erreur 
                if (Device.RuntimePlatform == Device.iOS)
                {
                    await DisplayAlert("Erreur", apiWeather.Message, "OK");
                } 
                else 
                { 
                    // déclanchement de code natif Android
                    Xamarin.Forms.DependencyService.Get<ToastInterface>().ShowToast(apiWeather.Message);
                }
            }



        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage("mathieu"));
            //App.Current.MainPage = new NavigationPage(new SecondPage("mathieu"));
        }
    }
}
