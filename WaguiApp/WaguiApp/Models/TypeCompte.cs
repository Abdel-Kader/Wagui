using System;
using System.Collections.Generic;
using System.Text;

namespace WaguiApp.Models
{
    public class TypeCompte
    {
        
        public int Id { get; set; }
        public bool agriculteur { get; set; }
        public bool investisseur { get; set; }
        public bool agronome { get; set; }
        public bool demandeur { get; set; }
    }
}
