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
    public partial class AideView : ContentPage
    {
        public AideView()
        {
            InitializeComponent();
            App.StartCheckIfInternet(lbl_NoInternet, this);
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Vente_production(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutArticlePage());
        }
    }
}