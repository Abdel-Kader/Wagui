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
    public partial class ArticlesVendus : ContentPage
    {
        public ArticlesVendus()
        {
            InitializeComponent();
        }

        private async void Btntxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutArticlePage());
        }
    }
}