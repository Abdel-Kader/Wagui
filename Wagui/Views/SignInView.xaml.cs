using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wagui.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wagui.Views.Inscription;
namespace Wagui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInView : ContentPage
    {
        public SignInModel signInModel;
        public SignInView()
        {
            InitializeComponent();
            signInModel = new SignInModel();
            App.StartCheckIfInternet(lbl_NoInternet, this);
            this.SizeChanged += PageChanged;
            /*
                        MessagingCenter.Subscribe<SignInModel, string[]>(this, "Alert", (sender, nom) =>
                        {
                            if (nom[1] == "Yess")
                            {
                                Application.Current.Properties["user_id"] = nom[0];
                                DisplayAlert("Alert", "Félicitation vous venez de créer votre compte ! Veuillez compléter votre inscription", "Continuer");
                                Navigation.PushAsync(new Inscription1());
                                //App.UserDatabase.SaveUser(user);
                            }
                            else
                            {
                                DisplayAlert("Alert", nom[1], "Fermer");
                            }
                        });
                        */

            MessagingCenter.Subscribe<SignInModel, string[]>(this, "Alert", async (sender, username) =>
            {
                if (username[4] == "Yess")
                {
                    App.IsUserLoggedIn = true;

                    Application.Current.Properties["user_id"] = username[0];
                    Application.Current.Properties["user_nom"] = username[1];
                    Application.Current.Properties["user_tel"] = username[3];
                    if(username[2] != null)
                    {
                        Application.Current.Properties["user_prenom"] = username[2];
                    }
                     
                    Navigation.InsertPageBefore(new Inscription1(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", username[4], "Fermer");
                }
            });
            this.BindingContext = signInModel;

            NomEntry.Completed += (object sender, EventArgs e) =>
            {
                PrenomEntry.Focus();
            };

            PrenomEntry.Completed += (object sender, EventArgs e) =>
            {
                PassEntry.Focus();
            };


            PassEntry.Completed += (object sender, EventArgs e) =>
            {
                RePassEntry.Focus();
            };

            RePassEntry.Completed += (object sender, EventArgs e) =>
            {
                TelEntry.Focus();
            };

            TelEntry.Completed += (object sender, EventArgs e) =>
            {
                signInModel.SubmitCommand.Execute(null);
            };

        }

        private void PageChanged(object sender, EventArgs e)
        {
            if ((this.Width > this.Height) || Device.Idiom == TargetIdiom.Tablet)
            {
                Main.Margin = new Thickness(100, 40, 100, 40);
                //col.Width = 400;
            }
            else
            {
                Main.Margin = new Thickness(40, 20, 40, 20);
                //col.Width = 300;
            }
        }
    }
}