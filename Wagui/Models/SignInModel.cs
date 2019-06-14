using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Wagui.Services;
using System.Threading.Tasks;

namespace Wagui.Models
{
    public class SignInModel : INotifyPropertyChanged
    {
        private HttpClient _client = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string nom;
        public string prenom;
        public string mdp;
        public string tel;
        public string rePassword;
        public bool isBusy = false;
        public bool isEnable = true;

        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nom"));
            }
        }


        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Prenom"));
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

        public string RePassword
        {
            get { return rePassword; }
            set
            {
                rePassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RePassword"));
            }
        }

        public string Telephone
        {
            get { return tel; }
            set
            {
                tel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Telephone"));
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

        public SignInModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            
            if (!string.IsNullOrEmpty(Nom) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Telephone) && !string.IsNullOrEmpty(RePassword))
            {
                IsBusy = true;
                IsEnable = false;
                await Task.Delay(2000);

                if (RePassword == Password)
                {
                    var user = new SignInModel()
                    {
                        nom = Nom,
                        prenom = Prenom,
                        tel = Telephone,
                        mdp = Password

                    };
                    var content = JsonConvert.SerializeObject(user);
                    var response = await _client.PostAsync(Constantes.accountApiUrl + "createUser", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                    var result = " ";


                    JsonConvert.DeserializeObject<SignInModel>(
                      result = await response.Content.ReadAsStringAsync()
                    );
                    var reponse = JsonConvert.DeserializeObject<Message>(result);
                    IsBusy = false;
                    IsEnable = true;
                    string[] user_data = { reponse.id, reponse.nom, reponse.prenom, reponse.tel, reponse.message };
                    MessagingCenter.Send(this, "Alert", user_data);
                }
                else
                {
                    MessagingCenter.Send(this, "Alert", "Les deux mots de passe doivent être identiques");
                }
                
            }
            //MessagingCenter.Send(this, "Alert", Nom);
            else
            {
                MessagingCenter.Send(this, "Alert", "Veuillez remplir les champs obligatoires SVP");
            }
        }


    }
}