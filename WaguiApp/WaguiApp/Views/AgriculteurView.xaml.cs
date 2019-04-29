using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WaguiApp.Views.Agriculteur;

namespace WaguiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgriculteurView : ContentPage
	{
		public AgriculteurView ()
		{
			InitializeComponent ();
		}

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Accueil(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Bienvenue sur Wagui", "Fermer");
            await Navigation.PushAsync(new Accueil());
        }
    }
}