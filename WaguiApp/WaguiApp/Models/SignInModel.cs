using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace WaguiApp.Models
{
    public class SignInModel : INotifyPropertyChanged
    {
        private HttpClient _client = new HttpClient();
        private ObservableCollection<SignInModel> _userRegistration;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string nom;
        public string prenom;
        public string password;
        public string telephone;
        public string email;
        public string passwordRepeat;

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
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string PasswordRepeat
        {
            get { return passwordRepeat; }
            set
            {
                passwordRepeat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PasswordRepeat"));
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Telephone"));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
        }

        public ICommand SubmitCommand { get; set; }

        public SignInModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            
            if (!string.IsNullOrEmpty(Nom) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PasswordRepeat))
            {
                if(PasswordRepeat == Password)
                {
                    var user = new SignInModel()
                    {
                        nom = Nom,
                        prenom = Prenom,
                        password = Password,
                        telephone = Telephone,
                        email = Email

                    };
                    var content = JsonConvert.SerializeObject(user);
                    var response = await _client.PostAsync(Constants.ApiUrl + "createUser", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                    var result = " ";


                    JsonConvert.DeserializeObject<SignInModel>(
                      result = await response.Content.ReadAsStringAsync()
                    );
                    var reponse = JsonConvert.DeserializeObject<Message>(result);
                    MessagingCenter.Send(this, "Alert", reponse.message);
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