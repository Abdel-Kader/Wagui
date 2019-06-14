using System.ComponentModel;

namespace Wagui.Models
{
    public class ListQuestionsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
         
            public string Question { get; set; }
            public string Date_debut { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            
            public bool IsVisible { get; set; }
    }

}
