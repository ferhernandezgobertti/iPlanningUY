using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class User : IUserable
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastEntry { get; set; }
        public bool FirstEntry { get; set; }
        public User() {
            this.Registration = DateTime.Now;
            this.LastEntry = DateTime.Now;
            this.FirstEntry = true;
        }
        public void UpdateLastEntry() {
            this.LastEntry = DateTime.Now;
        }

        public bool IsPasswordCorrect(String password) {
            return this.Password.Equals(password);
        }

        public bool IsPasswordRight() {
            return this.Password.Length >= 6 && IsPasswordWithUpper() && IsWordWithSymbol(this.Password, "0123456789") 
                && IsWordWithSymbol(this.Password, ".,;<>|/#&^!");
        }
        public bool IsPasswordWithUpper()
        {
            bool hasUpperCase = false;
            for (int letterPosition = 0; letterPosition < this.Password.Length; letterPosition++) {
                if (Char.IsUpper(this.Password[letterPosition])) {
                    hasUpperCase = true;
                    break;
                }
            }
            return hasUpperCase;
        }
        public bool IsWordWithSymbol(String word, String symbols) {
            bool hasSymbol = false;
            for (int symbolPosition = 0; symbolPosition < symbols.Length; symbolPosition++) {
                if (word.Contains(symbols[symbolPosition])) {
                    hasSymbol = true;
                    break;
                }
            }
            return hasSymbol;
        }

        public override bool IsDesigner() { return false;  }
        public override bool IsClient() { return false;  }
        public override bool IsArchitect() { return false;  }

        public override string ToString() {
            StringBuilder userData = new StringBuilder();
            userData.Append("UserName: ");
            userData.Append(this.UserName);
            userData.Append(" Password: ");
            userData.Append(this.Password);
            userData.Append(" Name: ");
            userData.Append(this.Name);
            userData.Append(" Surname: ");
            userData.Append(this.Surname);
            userData.Append(" Registration Date: ");
            userData.Append(this.Registration);
            userData.Append(" Last Entry: ");
            userData.Append(this.Registration);
            return userData.ToString();
        }

        public override bool Equals(object anObject) {
            User anUser = anObject as User;

            if (anUser == null)
                return false;

            return this.UserName.Equals(anUser.UserName) && this.Password.Equals(anUser.Password);
        }


    }
}
