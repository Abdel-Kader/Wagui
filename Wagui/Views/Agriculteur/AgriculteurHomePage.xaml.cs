using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wagui.Views.Agriculteur.VentePage;
namespace Wagui.Views.Agriculteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgriculteurHome : ContentPage
    {
        public AgriculteurHome()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
            App.StartCheckIfInternet(lbl_NoInternet, this);
            if (Application.Current.Properties.ContainsKey("user_id"))
            {
                nom.Text = Application.Current.Properties["user_nom"].ToString();
            }
        }

        private async void new_question(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionView());
        }

        private async void aidePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AideView());
        }

        private async void Profil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilView());
        }
        private async void Questions(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MesQuestions());
        }

        private void Deconnexion(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginView(), this);
            Navigation.PopAsync();
        }

        private async void Mes_offres(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MesOffresView());
        }
    }
}