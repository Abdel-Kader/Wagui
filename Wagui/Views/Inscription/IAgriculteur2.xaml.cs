using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wagui.Models;
using Wagui.Views.Agriculteur;

namespace Wagui.Views.Inscription
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IAgriculteur2 : ContentPage
    {
        public AddCultureModel addCultureModel;
        public IAgriculteur2()
        {
            InitializeComponent();

            App.StartCheckIfInternet(lbl_NoInternet, this);

            addCultureModel = new AddCultureModel();

            
            MessagingCenter.Subscribe<AddCultureModel, string>(this, "Alert", (sender, nom) =>
            {
                if (nom == "Yess")
                {
                    Navigation.PushAsync(new IAgriculteur3());
                    //App.UserDatabase.SaveUser(user);
                }
                else
                {
                    DisplayAlert("Alert", nom, "Fermer");
                }
            });
            this.BindingContext = addCultureModel;

            LibelleEntry.Completed += (object sender, EventArgs e) =>
            {
                DimensionEntry.Focus();
            };

            DimensionEntry.Completed += (object sender, EventArgs e) =>
            {
                CommentaireEntry.Focus();
            };


            CommentaireEntry.Completed += (object sender, EventArgs e) =>
            {
                DateEntry.Focus();
            };

        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IAgriculteur3());
        }

        private async void Cancel_click(object sender, EventArgs e)
        {
            Application.Current.Properties["step"] = "cancel2";
            Navigation.InsertPageBefore(new AgriculteurHome(), this);
            await Navigation.PopAsync();
        }


    }
}