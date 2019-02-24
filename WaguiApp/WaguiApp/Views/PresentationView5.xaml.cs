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
	public partial class PresentationView5 : ContentPage
	{
		public PresentationView5 ()
		{
			InitializeComponent ();
		}

        private async void Inscription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}