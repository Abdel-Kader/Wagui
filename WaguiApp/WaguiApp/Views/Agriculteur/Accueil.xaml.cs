using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaguiApp.Views.Agriculteur
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Accueil : ContentPage
	{
		public Accueil ()
		{
			InitializeComponent ();
		}

        private async void Question(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new question());
        }

        private async void Aide(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Aide());
        }
    }
}