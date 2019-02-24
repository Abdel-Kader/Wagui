using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaguiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inscription1View : ContentPage
	{
		public Inscription1View ()
		{
			InitializeComponent ();
		}

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Inscription2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inscription2View());
        }
    }
}