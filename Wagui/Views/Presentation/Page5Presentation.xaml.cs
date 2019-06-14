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
    public partial class Page5Presentation : ContentPage
    {
        public Page5Presentation()
        {
            InitializeComponent();
        }

        private async void InscriptionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInView());
        }
    }
}