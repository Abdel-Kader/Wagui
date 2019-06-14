using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Inscription
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inscription1 : ContentPage
    {
        public Inscription1()
        {
            InitializeComponent();
        }

        private async void IAgriculteur1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inscription2());
        }
    }
}