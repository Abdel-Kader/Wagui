using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Wagui.Services;
using System.Threading.Tasks;

namespace Wagui.Models
{
    public class AddQuestionModel : INotifyPropertyChanged
    {
        private HttpClient _question = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string question;
        public string id_agri;
        public bool isBusy = false;
        public bool isEnable = true;

        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Question"));
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));

            }
        }

        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsEnable"));

            }
        }

        public string Id_agri { get; set; } = Application.Current.Properties["user_id"].ToString();

        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
        }

        public ICommand SubmitCommand { get; set; }

        public AddQuestionModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            

            if (!string.IsNullOrEmpty(Question))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);
                var quest = new AddQuestionModel()
                {
                    question = Question,
                    id_agri = Application.Current.Properties["user_id"].ToString(),
                };
                var content = JsonConvert.SerializeObject(quest);

                var response = await _question.PostAsync(Constantes.agriApiUrl + "newQuestion", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";
                
                JsonConvert.DeserializeObject<AddQuestionModel>(
                    result = await response.Content.ReadAsStringAsync()
                    );
                var reponse = JsonConvert.DeserializeObject<Message>(result);
                
               IsBusy = false;
               IsEnable = true;
                MessagingCenter.Send(this, "Alert", reponse.message);
                
            }
            else
            {
                MessagingCenter.Send(this, "Alert", "Veuillez remplir tous les champs SVP");
            }
        }
    }
}
