using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WaguiApp.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        private HttpClient _client = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string email;
        public string password;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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

        public class Message
        {
            public string error { get; set; }
            public string message { get; set; }
        }

        public ICommand SubmitCommand { get; set; }

        public LoginModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var user = new LoginModel()
                {
                    email = Email,
                    password = Password
                };
                var content = JsonConvert.SerializeObject(user);
                var response = await _client.PostAsync(Constants.ApiUrl + "userLogin", new StringContent(content, UnicodeEncoding.UTF8, "application/json"));
                var result = "";

                JsonConvert.DeserializeObject<LoginModel>(
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
