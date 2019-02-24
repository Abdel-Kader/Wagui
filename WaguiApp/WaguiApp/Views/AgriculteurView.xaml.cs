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
    }
}