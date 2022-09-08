namespace TemperatureForms
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TemperatureForms.Models;
    using TemperatureForms.Utils;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Temps> tempsList = new ObservableCollection<Temps>();


        public MainPage()
        {
            InitializeComponent();

            ListViewData.ItemsSource = tempsList;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Button b = sender as Button;
            //b.Text = "Save";

            var celsius = EntryCelsius.Text;
            var far = EntryFahrenheit.Text;

            //Console.WriteLine("mathieu: "+celsius+" "+far);

            // ajout d'une châine dans la liste C# avec les valeur celsius / far des 2 champs
            tempsList.Add(new Temps(celsius, far));

        }

        private void EntryCelsius_TextChanged(object sender, TextChangedEventArgs e)
        {
            var valeur = e.NewTextValue; // récupération de la dernière valeur saisie

            if(EntryCelsius.IsFocused && Double.TryParse(valeur, out double result))
            {
                EntryFahrenheit.Text = TemperatureConverter.FahrenheitFromCelcius(result);
            }


        }

        private void EntryFahrenheit_TextChanged(object sender, TextChangedEventArgs e)
        {
            var valeur = e.NewTextValue; // récupération de la dernière valeur saisie

            if (EntryFahrenheit.IsFocused && Double.TryParse(valeur, out double result))
            {
                EntryCelsius.Text = TemperatureConverter.CelciusFromFahrenheit(result);
            }
        }

        private void ListViewData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            RemoveItemAsync(e);
        }

        private async Task RemoveItemAsync(ItemTappedEventArgs e)
        {
            var remove = await DisplayAlert("Alerte", "Êtes-vous sur ?", "Oui", "Non");

            if (remove)
            {
                //tempsList.Remove(e.Item as Temps);
                tempsList.RemoveAt(e.ItemIndex);

                await DisplayAlert("Alerte", "Donnée effacé", "Fermer");
            }
        }
    }
}
