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
    public class UpdateTypeModel : INotifyPropertyChanged
    {
        private HttpClient _typeCompte = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string type_profil;
        public string id;
        public bool isBusy = false;
        public bool isEnable = true;

        public string Type_Profil
        {
            get { return type_profil; }
            set
            {
                type_profil = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Type_Profil"));
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

        public string Id { get; set; } = Application.Current.Properties["user_id"].ToString();

        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
        }

        public ICommand SubmitCommand { get; set; }

        public UpdateTypeModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {


            if (!string.IsNullOrEmpty(Type_Profil))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);
                var profil = new UpdateTypeModel()
                {
                    type_profil = Type_Profil                    
                };
                var content = JsonConvert.SerializeObject(profil);

                var response = await _typeCompte.PutAsync(Constantes.accountApiUrl + "updateType/"+ Application.Current.Properties["user_id"].ToString(), new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";

                JsonConvert.DeserializeObject<UpdateTypeModel>(
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

