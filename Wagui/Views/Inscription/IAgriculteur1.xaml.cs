using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wagui.Views.Agriculteur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Inscription
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IAgriculteur1 : ContentPage
    {
        public IAgriculteur1()
        {
            InitializeComponent();
            //App.StartCheckIfInternet(lbl_NoInternet, this);
            this.SizeChanged += PageChanged;

        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IAgriculteur2());
        }

        private async void Cancel_click(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            Application.Current.Properties["step"] = "cancel1";
            Navigation.InsertPageBefore(new AgriculteurHome(), this);
            await Navigation.PopAsync();
        }
        private void PageChanged(object sender, EventArgs e)
        {
            if ((this.Width > this.Height) || Device.Idiom == TargetIdiom.Tablet)
            {
                Main.Margin = new Thickness(100, 40, 100, 40);
                
            }
            else
            {
                Main.Margin = new Thickness(40, 20, 40, 20);
                
            }
        }
    }
}