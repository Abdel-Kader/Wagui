using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaguiApp.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string Nom, string Prenom, string Password, string Telephone, string Email)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Password = Password;
            this.Telephone = Telephone;
            this.Email = Email;
        }

        public bool CheckInformation()
        {
            if (!this.Nom.Equals("") && !this.Password.Equals("") && !this.Email.Equals(""))
                return true;
            else
                return false;
        }
    }
}
