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
    public partial class Page4Presentation : ContentPage
    {
        public Page4Presentation()
        {
            InitializeComponent();
        }

        private async void Page5Presentation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page5Presentation());
        }

        private async void InscriptionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}