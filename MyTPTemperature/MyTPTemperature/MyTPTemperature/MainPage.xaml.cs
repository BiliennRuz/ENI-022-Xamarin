using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTPTemperature
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<ConvertList> enregistrements = new ObservableCollection<ConvertList>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            enregistrements.Add(new ConvertList
            {
                TempCelcius = TempCelcius.Text.ToString(),
                TempFahrenheit = TempFahrenheit.Text.ToString(),
            });
            this.List.ItemsSource = enregistrements;
        }

        private void TempCelcius_Completed(object sender, EventArgs e)
        {
            TempFahrenheit.Text = TemperatureConverter.FahrenheitFromCelcius(Convert.ToDouble(TempCelcius.Text));
        }

        private void TempFahrenheit_Completed(object sender, EventArgs e)
        {
            TempCelcius.Text = TemperatureConverter.CelciusFromFahrenheit(Convert.ToDouble(TempFahrenheit.Text)); 
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            enregistrements.RemoveAt(e.ItemIndex);
        }
    }
}
