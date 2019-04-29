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
	public partial class PresentationView3 : ContentPage
	{
		public PresentationView3 ()
		{
			InitializeComponent ();
		}

        private async void Presentation4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PresentationView4());
        }

        private async void Inscription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}