using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Agriculteur.AchatPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailArticle : ContentPage
    {
        public DetailArticle()
        {
            InitializeComponent();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}