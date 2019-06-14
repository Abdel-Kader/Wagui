using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Wagui.Services;

namespace Wagui.Models
{
    public class PlanteModel : INotifyPropertyChanged
    {
        private HttpClient _question = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string question;
        public string id_user;
    }
}
