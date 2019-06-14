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
    public partial class Inscription2 : ContentPage
    {
        public Inscription2()
        {
            InitializeComponent();
        }

        public void AlertPicker(object sender, EventArgs e)
        {
            var name = Typecompte.Items[Typecompte.SelectedIndex];
            if (name == "Agriculteurs")
            {
                detailLabel.Text = "Et j'aimerais augmenter ma production ou trouver des solutions aux problèmes que je rencontre lors de l'exercice de mon activité";
                content.BackgroundImage = "ins_agri1";
            }
            if (name == "Acheteurs")
            {
                detailLabel.Text = "Et je souhaite mettre mes moyens dans un projet agricol intéressant avec un fort potentiel de croissance";
                content.BackgroundImage = "ins_inv1";
            }
            if (name == "Agronome")
            {
                detailLabel.Text = "Et j'aimerais aider les agriculteurs et autres acteurs du secteur agricol par mes connaissances techniques des plantes et leurs crissances";
                content.BackgroundImage = "ins_agro1";
            }
           
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            if(Typecompte.SelectedIndex !=-1)
            {
                var name = Typecompte.Items[Typecompte.SelectedIndex];
                if (name == "Agriculteurs")
                {
                    await Navigation.PushAsync(new IAgriculteur1());
                }
                else
                {
                    await DisplayAlert("Alerte", "Bientôt", "Fermer");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Veuillez sélectionner un élement de la liste", "Fermer");
            }

        }
    }
}