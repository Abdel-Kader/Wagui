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
    public partial class Page1Presentation : ContentPage
    {
        public Page1Presentation()
        {
            InitializeComponent();
        }

        private async void Page2Presentation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2Presentation());
        }
    }
}