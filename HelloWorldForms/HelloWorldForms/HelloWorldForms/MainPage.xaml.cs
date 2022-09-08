namespace HelloWorldForms
{
    using System;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); // affichage du layout et gestion da la récupération des composants graphiques

            StackLayoutConnexion.IsVisible = true;
            ScrollViewTwitter.IsVisible = false;

            EntryUsername.Text = Preferences.Get("login", null);
            EntryPassword.Text = Preferences.Get("password", null);
            SwitchSaveConnexion.IsToggled = Preferences.Get("switch", false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // TODO : vérifier la saisie dans les champs de login et de mot de passe

            LabelError.Text = "";

            var username = String.IsNullOrEmpty(EntryUsername.Text) ? "" : EntryUsername.Text.ToString();
            if (username.Length < 3)
            {
                LabelError.Text = "Vous devez renseigner au moins 3 caractères pour le login";
                return;
            }
            
            var password = String.IsNullOrEmpty(EntryPassword.Text) ? "" : EntryPassword.Text.ToString();
            if (password.Length < 6)
            {
                LabelError.Text = "Vous devez renseigner au moins 6 caractères pour le mot de passe";
                return;
            }

            // TODO : vérifier que le login et le mot de passe correspondent bien au valeurs définis
            var loginController = "mathieu";
            var passwordController = "123456";

            if(loginController != username || !passwordController.Equals(password))
            {
                LabelError.Text = "Vous devez saisir un identifiant et un mot de passe valide";
                return;
            }

            // TODO : cacher le formulaire de login et afficher le scrollview
            StackLayoutConnexion.IsVisible = false;
            ScrollViewTwitter.IsVisible = true;

            // TODO : gérer la mémorisation de la session
            Preferences.Set("login", SwitchSaveConnexion.IsToggled ? username : null);
            Preferences.Set("password", SwitchSaveConnexion.IsToggled ? password : null);
            Preferences.Set("switch", SwitchSaveConnexion.IsToggled);
        }
    }
}
