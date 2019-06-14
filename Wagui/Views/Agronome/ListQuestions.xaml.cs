using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wagui.Models;
using Wagui.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Agronome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListQuestions : ContentPage
    {
        public ListQuestionsModel listQuestionsModel;

        public ListQuestions()
        {
            InitializeComponent();
            getAllQuestion();

        }

        public async void getAllQuestion()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.waguispace.com/mobile/agriculteur_api/getAllQuestions");
            var listQuestions = JsonConvert.DeserializeObject<List<ListQuestionsModel>>(response);
            MyListView.ItemsSource = listQuestions;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void repondre(object sender, EventArgs e)
        {

        }
    }
}
