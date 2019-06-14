using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wagui.Models;


namespace Wagui.Views.Agriculteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionView : ContentPage
    {
        public AddQuestionModel addQuestionModel;

        public QuestionView()
        {
            InitializeComponent();

            App.StartCheckIfInternet(lbl_NoInternet, this);

            addQuestionModel = new AddQuestionModel();

            MessagingCenter.Subscribe<AddQuestionModel, string>(this, "Alert", (sender, response) =>
            {
                Console.WriteLine("rrrrrrrrrrrrrrr "+response);
                if (response == "Yess")
                {
                    DisplayAlert("Alert", "Vore question a été ajoutée avec succès", "Fermer");
                    QuestionEntry.Text = string.Empty;
                }
                else
                {
                    DisplayAlert("Alert", response, "OK");
                }

            });
            this.BindingContext = addQuestionModel;

        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}