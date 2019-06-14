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
    public class AddCultureModel : INotifyPropertyChanged
    {
        private HttpClient _culture = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string libelle;
        public string dimensions;
        public string date_creation;
        public string commentaire;
        public string id_wag_user;
        public bool isBusy = false;
        public bool isEnable = true;

        public string Libelle
        {
            get { return libelle; }
            set
            {
                libelle = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Libelle"));
            }
        }

        public string Dimensions
        {
            get { return dimensions; }
            set
            {
                dimensions = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dimensions"));
            }
        }

        public string Date_creation
        {
            get { return date_creation; }
            set
            {
                date_creation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Date_creation"));
            }
        }

        public string Commentaire
        {
            get { return commentaire; }
            set
            {
                commentaire = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Commentaire"));
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
        public string Id_wag_user { get; set; } = Application.Current.Properties["user_id"].ToString();


        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
        }

        public ICommand SubmitCommand { get; set; }


        public AddCultureModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            if (!string.IsNullOrEmpty(Libelle))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);

                var culture = new AddCultureModel()
                {
                    libelle = Libelle,
                    dimensions = Dimensions,
                    date_creation = Date_creation,
                    commentaire = Commentaire,
                    id_wag_user = Application.Current.Properties["user_id"].ToString()

            };
                var content = JsonConvert.SerializeObject(culture);
                var response = await _culture.PostAsync(Constantes.agriApiUrl + "addCulture", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";

                JsonConvert.DeserializeObject<AddCultureModel>(
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
