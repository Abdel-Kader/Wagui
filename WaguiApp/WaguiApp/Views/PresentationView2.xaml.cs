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
	public partial class PresentationView2 : ContentPage
	{
		public PresentationView2 ()
		{
			InitializeComponent ();
		}

        private async void Presentation3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PresentationView3());
        }

        private async void Inscription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}