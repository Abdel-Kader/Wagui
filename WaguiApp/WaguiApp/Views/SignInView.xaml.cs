using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaguiApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaguiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInView : ContentPage
	{
        public SignInModel signInModel;

		public SignInView ()
		{
			InitializeComponent ();
            signInModel = new SignInModel();

            //var user = new User(NomEntry.Text, PrenomEntry.Text, PasswordEntry.Text, TelephoneEntry.Text, EmailEntry.Text);

            MessagingCenter.Subscribe<SignInModel, string>(this, "Alert", (sender, nom) => 
            {
                if(nom == "Yess")
                {
                    Navigation.PushAsync(new Inscription1View());
                    //App.UserDatabase.SaveUser(user);
                }
                else
                {
                    DisplayAlert("Alert", nom, "Fermer");
                }
            });
            this.BindingContext = signInModel;

            NomEntry.Completed += (object sender, EventArgs e) =>
            {
                PrenomEntry.Focus();
            };

            PrenomEntry.Completed += (object sender, EventArgs e) =>
            {
                PasswordEntry.Focus();
            };

           
            PasswordEntry.Completed += (object sender, EventArgs e) =>
            {
                PasswordRepeatEntry.Focus();
            };

            PasswordRepeatEntry.Completed += (object sender, EventArgs e) =>
            {
                TelephoneEntry.Focus();
            };

            TelephoneEntry.Completed += (object sender, EventArgs e) =>
            {
                EmailEntry.Focus();
            };

            EmailEntry.Completed += (object sender, EventArgs e) =>
            {
                signInModel.SubmitCommand.Execute(null);
            };



        }
    }
}
