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
    public class LoginModel : INotifyPropertyChanged
    {
        private HttpClient _client = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string tel;
        public string mdp;
        public bool isBusy = false;
        public bool isEnable = true;
        public string Telephone
        {
            get { return tel; }
            set
            {
                tel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Telephone"));
            }
        }


        public string Password
        {
            get { return mdp; }
            set
            {
                mdp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
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
        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
            public string id { get; set; }
            public string nom { get; set; }
            public string prenom { get; set; }
            public string tel { get; set; }
        }

        public ICommand SubmitCommand { get; set; }

        public LoginModel()
        {
            
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            
            if (!string.IsNullOrEmpty(Telephone) && !string.IsNullOrEmpty(Password))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);
                var user = new LoginModel()
                {
                    tel = Telephone,
                    mdp = Password
                };
                var content = JsonConvert.SerializeObject(user);

                var response = await _client.PostAsync(Constantes.accountApiUrl + "userLogin", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";

                JsonConvert.DeserializeObject<LoginModel>(
                    result = await response.Content.ReadAsStringAsync()
                    );
                var reponse = JsonConvert.DeserializeObject<Message>(result);
                IsBusy = false;
                IsEnable = true;
                string[] user_data= { reponse.id, reponse.nom, reponse.prenom, reponse.tel, reponse.message };
                MessagingCenter.Send(this, "Alert", user_data);

            }
            else
            {
                MessagingCenter.Send(this, "Alert", "Veuillez remplir tous les champs SVP");
            }
        }

       
    }
}
