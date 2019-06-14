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
    public partial class AchatHomePage : ContentPage
    {
        public AchatHomePage()
        {
            InitializeComponent();
        }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailArticle());
        }
    }
}