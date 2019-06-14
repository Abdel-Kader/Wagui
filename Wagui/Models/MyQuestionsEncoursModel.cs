using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Wagui.Models
{
   public class MyQuestionsEncoursModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string Question { get; set; }
        public string Date_debut { get; set; }
        
    }
}
