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
	public partial class Inscription2View : ContentPage
	{
		public Inscription2View ()
		{
			InitializeComponent ();
		}
        
       public void AlertPicker(object sender, EventArgs e)
        {
            var name = Typecompte.Items[Typecompte.SelectedIndex];
            if(name == "Agriculteur")
            {
                detailLabel.Text = "Et j'aimerais augmenter ma production ou trouver des solutions aux problèmes que je rencontre lors de l'exercice de mon activité";
            }
            if (name == "Investisseur")
            {
                detailLabel.Text = "Et je souhaite mettre mes moyens dans un projet agricol intéressant avec un fort potentiel de croissance";
            }
            if (name == "Agronome")
            {
                detailLabel.Text = "Et j'aimerais aider les agriculteurs et autres acteurs du secteur agricol par mes connaissances techniques des plantes et leurs crissances";
            }
            if (name == "Demandeur")
            {
                detailLabel.Text = "Et j'aimerais aider les agriculteurs et autres acteurs du secteur agricol par mes compétences et/ou redécouvrir le travail de la terre ";
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            var name = Typecompte.Items[Typecompte.SelectedIndex];
            if (name == "Agriculteur")
            {
                await Navigation.PushAsync(new AgriculteurView());
            }
            else
            {
                await DisplayAlert("Alert", "Bientôt", "Fermer");
            }
        }

        
    }
}