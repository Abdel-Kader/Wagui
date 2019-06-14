using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Presentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3Presentation : ContentPage
    {
        public Page3Presentation()
        {
            InitializeComponent();
        }

        private async void Page4Presentation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page4Presentation());
        }

        private async void InscriptionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}