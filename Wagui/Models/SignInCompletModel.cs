using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Wagui.Services;
using System.Threading.Tasks;

namespace Wagui.Models
{
    public class SignInCompletModel : INotifyPropertyChanged
    {
        private readonly HttpClient _client = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string sexe;
        public string age;
        public string id_agri;
        public string photo;
        public bool isBusy = false;
        public bool isEnable = true;

        public string Sexe
        {
            get { return sexe; }
            set
            {
                sexe = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Sexe"));
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Age"));
            }
        }

        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Photo"));
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
        }

        public ICommand SubmitCommand { get; set; }

        public SignInCompletModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            if (!string.IsNullOrEmpty(Age))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);
                var user = new SignInCompletModel()
                {
                    sexe = Sexe,
                    age = Age,
                    id_agri = Application.Current.Properties["user_id"].ToString()

                };

                var content = JsonConvert.SerializeObject(user);
                var response = await _client.PutAsync(Constantes.accountApiUrl + "completeUser/" + Application.Current.Properties["user_id"].ToString(), new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";

                JsonConvert.DeserializeObject<SignInCompletModel>(
                    result = await response.Content.ReadAsStringAsync()
                    );
                var reponse = JsonConvert.DeserializeObject<Message>(result);
                MessagingCenter.Send(this, "Alert", reponse.message);
            }
            else
            {
                MessagingCenter.Send(this, "Alert", "Veuillez remplir tous les champs SVP");
            }
        }

    }
}
