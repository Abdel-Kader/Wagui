using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaguiApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WaguiApp.Views.Agriculteur;

namespace WaguiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
        public LoginModel loginModel;


        public LoginView ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
            App.StartCheckIfInternet(lbl_NoInternet, this);

            loginModel = new LoginModel();
            MessagingCenter.Subscribe<LoginModel, string>(this, "Alert", (sender, username) =>
            {
                this.IsBusy = true;
                if(username == "Vous êtes maintenant connecté !")
                {
                    Navigation.PushAsync(new Accueil());
                }
                else
                {
                    DisplayAlert("Alert", username, "OK");
                }
                
            });
            this.BindingContext = loginModel;
           

            UsernameEntry.Completed += (object sender, EventArgs e) =>
            {
                PasswordEntry.Focus();
            };

            PasswordEntry.Completed += (object sender, EventArgs e) =>
            {
                loginModel.SubmitCommand.Execute(null);
            };
            
        }

        private async void Presentation1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PresentationView1());
        }
    }
}