using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wagui.Models;
using Wagui.Views.Presentation;
using Wagui.Views.Agriculteur;


namespace Wagui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginModel loginModel;
        public LoginView()
        {
            InitializeComponent();
           
            App.StartCheckIfInternet(lbl_NoInternet, this);
            this.SizeChanged += PageChanged;

            loginModel = new LoginModel();
            MessagingCenter.Subscribe<LoginModel, string[]>(this, "Alert", async (sender, username) =>
            {
                if (username[4] == "Vous êtes maintenant connecté !")
                {
                    App.IsUserLoggedIn = true;
                   
                    Application.Current.Properties["user_id"] = username[0];
                    Application.Current.Properties["user_nom"] = username[1];
                    Application.Current.Properties["user_prenom"] = username[2];
                    Application.Current.Properties["user_tel"] = username[3];
                    Navigation.InsertPageBefore(new AgriculteurHome(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", username[4], "OK");
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

        private void PageChanged(object sender, EventArgs e)
        {
            if((this.Width > this.Height) || Device.Idiom == TargetIdiom.Tablet)
            {
                Main.Margin = new Thickness(100,40,100,40);
               // col.Width = 400;
                //col2.Width = 400;
            }
            else
            {
                Main.Margin = new Thickness(40, 20, 40, 20);
               // col.Width = 300;
                //col2.Width = 300;
            }
        }

        private async void Page1Presentation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1Presentation());
        }

    }
}