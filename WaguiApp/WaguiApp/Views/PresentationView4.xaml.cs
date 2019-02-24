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
	public partial class PresentationView4 : ContentPage
	{
		public PresentationView4 ()
		{
			InitializeComponent ();
		}

        private async void Presentation5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PresentationView5());
        }
    }
}