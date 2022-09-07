using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MyTPModule4
{
    public partial class MainPage : ContentPage
    {
        public static string IdUser = "Dom";
        public static string Password = "123";
        public MainPage()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("IdUser") && Preferences.ContainsKey("Password"))
            {
                if (Preferences.Get("IdUser", "default_value") == IdUser && Preferences.Get("Password", "default_value") == Password)
                {
                    StackLayoutConnexion.IsVisible = false;
                    ScrollViewTxitter.IsVisible = true;
                }
            } else
            {
            StackLayoutConnexion.IsVisible = true;
            ScrollViewTxitter.IsVisible = false;
            ErrorMessageId.IsVisible = false;
            ErrorMessagePwd.IsVisible = false;
            ErrorMessageOk.IsVisible = false;

            }

            Preferences.Get("IdUser", "default_value");

        }

        private void SeConnecter_Clicked(object sender, EventArgs e)
        {

            // recupération des entrées

            String EntryIdTwitter = this.EntryIdTwitter.Text.ToString();
            String EntryPasswordTwitter = this.EntryPasswordTwitter.Text.ToString();
            Boolean CheckEntryOk = false;
            Boolean CheckConnectOK = false;

            Console.WriteLine("EntryIdTwitter" + EntryIdTwitter);
            Console.WriteLine("EntryPasswordTwitter" + EntryPasswordTwitter);

            // check validité des entrées
            if (EntryIdTwitter.Length < 3)
            {
                ErrorMessageId.IsVisible = true;
                ErrorMessageId.Text = "L'identifiant doit contenir au moins 2 caractères";
                CheckEntryOk = true;
            }
            if (EntryPasswordTwitter.Length < 3)
            {
                ErrorMessagePwd.IsVisible = true;
                ErrorMessagePwd.Text = "Le mot de passe doit contenir au moins 2 caractères";
                CheckEntryOk = true;
            }
            
            // cacher le formulaire et afficher le scrollview
            if (CheckEntryOk)
            {
                if (EntryIdTwitter == IdUser)
                {
                    if (EntryPasswordTwitter == Password)
                    {
                        StackLayoutConnexion.IsVisible = false;
                        ScrollViewTxitter.IsVisible = true;
                        ErrorMessageOk.IsVisible = true;
                        ErrorMessageOk.Text = "Vous êtes connecté";
                        CheckConnectOK = true;
                    }
                    else
                    {
                        ErrorMessagePwd.IsVisible = true;
                        ErrorMessagePwd.Text = "Le mot de passe est incorecte";
                    }
                } else
                {
                    ErrorMessageId.IsVisible = true;
                    ErrorMessageId.Text = "L'identifiant n'existe pas";
                }

            }

            // gestion de la mémorisation de session
            if (CheckConnectOK)
            {
                if (SwitchSaveConnection.IsToggled)
                {
                    Preferences.Set("IdUser", IdUser);
                    Preferences.Set("Password", Password);
                }

            }


            //(sender as Button).Text = "I was just clicked!";

        }
    }
}
