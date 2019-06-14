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

namespace Wagui.Views.Agriculteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsEncours : ContentPage
    {
        public MyQuestionsEncoursModel myQuestionsEncoursModel;
        public string id_user = Application.Current.Properties["user_id"].ToString();
        public QuestionsEncours()
        {
            InitializeComponent();
            getAllQuestion();
        }

        public async void getAllQuestion()
        {
            await Task.Delay(2000);
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.waguispace.com/mobile/agriculteur_api/getMyQuestionsEncours/"+ id_user);
            var listQuestions = JsonConvert.DeserializeObject<List<MyQuestionsEncoursModel>>(response);
            activity.IsVisible = false;
            MyListView.IsVisible = true;
            MyListView.ItemsSource = listQuestions;
            if((MyListView.ItemsSource as List<MyQuestionsEncoursModel>).Count == 0)
                {
                await DisplayAlert("OK", "Yess", "hj");
            }
        }
    }
}