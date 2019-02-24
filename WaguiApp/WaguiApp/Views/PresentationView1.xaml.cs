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
    public partial class PresentationView1 : ContentPage
    {
        public PresentationView1()
        {
            InitializeComponent();
        }

        private async void Presentation2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PresentationView2());
        }
    }

    
}