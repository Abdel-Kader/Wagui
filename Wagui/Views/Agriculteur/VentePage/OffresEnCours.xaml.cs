using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Agriculteur.VentePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffresEnCours : ContentPage
    {
        public OffresEnCours()
        {
            InitializeComponent();
        }

        private async void Btntxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutArticlePage());
        }
    }
}