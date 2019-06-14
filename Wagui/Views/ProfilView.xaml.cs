using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wagui.Views.Inscription;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilView : ContentPage
    {
        public ProfilView()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("user_id"))
            {

                nom.Text = Application.Current.Properties["user_nom"].ToString();

                if (Application.Current.Properties.ContainsKey("user_prenom"))
                {
                    prenom.Text = Application.Current.Properties["user_prenom"].ToString();
                }
                else { prenom.Text = ""; }
                tel.Text = Application.Current.Properties["user_tel"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("step"))
            {
                EditBtn.IsVisible = true;
            }
            
        }
        public async void Edit_profil(object sender, EventArgs e)
        {
            if(Application.Current.Properties["step"].ToString() == "cancel1")
            {
                 await Navigation.PushAsync(new IAgriculteur1());
            }
            else if(Application.Current.Properties["step"].ToString() == "cancel2")
            {
                await Navigation.PushAsync(new IAgriculteur2());
            }
            else
            {
                await Navigation.PushAsync(new IAgriculteur3());
            }
        }
    }
}