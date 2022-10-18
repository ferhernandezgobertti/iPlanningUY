using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Domain
{
    
    public class Client : User, IRegistrable, ILoggable
    {
        public String NumberID { get; set; }
        public String Telephone { get; set; }
        public String Address { get; set; }

        public bool IsWellRegistered() {
            return this.IsPasswordRight() && this.UserName.Length <= 10 && this.UserName.Length >= 4
                && !this.IsWordWithSymbol(this.Name, " ") && !this.IsWordWithSymbol(this.Surname, " ") && 
                this.IsNumberIDRight() && this.IsTelephoneRight() && this.IsWordWithSymbol(this.Address, " ") 
                && this.IsWordWithSymbol(this.Address, "0123456789");
        }

        public String[] InitEditing(Form editingForm) {
            editingForm.Size = new Size(editingForm.Size.Width, 600);
            String[] clientData = { this.UserName, this.Name, this.Surname, this.NumberID, this.Telephone, this.Address };
            return clientData;
        }

        public void GetDataEditing(String[] userData) {
            this.UserName = userData[0];
            this.Name = userData[1];
            this.Surname = userData[2];
            this.NumberID = userData[3];
            this.Telephone = userData[4];
            this.Address = userData[5];
        }

        public bool StoreData (SketchItApp program, IRegistrable clientForList) {
            bool correctSearch = false;
            var index = program.Users.IndexOf(program.GetClientFromList(this));
            if (correctSearch = (index != -1)) {
                program.Users[index] = (Client)clientForList;
            }
            return correctSearch;
        }

        public void ChangePassword(SketchItApp program, String newPassword) {
            program.GetClientFromList(this).Password = newPassword;
        }

        public bool PasswordEquals(String newPassword) {
            return this.Password.Equals(newPassword);
        }

        public ILoggable CheckLogIn(SketchItApp program, String username, String password) {
            Client clientTyped = new Client();
            clientTyped.UserName = username;
            clientTyped.Password = password;
            Client clientFound = new Client();
            if ((clientFound = program.GetClientFromList(clientTyped)) != null && clientFound.IsPasswordCorrect(password)) {
                program.GetClientFromList(clientFound).UpdateLastEntry();
                return clientFound;
            } else {
                return null;
            }
        }

        public bool IsNumberIDRight() {
            bool numberRight = false;
            String numberID = this.NumberID;
            if (numberID.Length == 11) { // More or Equal than 1.000.000-0
                numberRight = this.CheckNewNumberID();
            }
            if (numberID.Length == 9) { // Less than 1.000.000-0
                numberRight = this.CheckOldNumberID(this.NumberID);
            }
            return numberRight;
        }

        public bool CheckNewNumberID() {
            return Char.IsDigit(this.NumberID[0]) && this.NumberID[0]!='0' && this.NumberID[1]=='.' 
                && this.CheckOldNumberID(this.NumberID.Substring(2));
        }

        public bool CheckNumberWithCeros(String division, int aNumber) {
            return CheckRangePositiveNumber(aNumber,3) || (CheckRangePositiveNumber(aNumber,2) && division.First<char>() == '0') || (CheckRangePositiveNumber(aNumber,1) && division.First<char>() == '0' && division.ElementAt<char>(1) == '0');
        }

        public bool CheckOldNumberID(String numberIDTyped) {
            bool numberIDRight = true;
            int aNumber, otherNumber;
            char[] tokens = { '.', '-' };
            String[] divisionsOfNumberID = numberIDTyped.Split(tokens[0]);
            if (divisionsOfNumberID.Length == 2 && int.TryParse(divisionsOfNumberID[0], out aNumber)) {
                numberIDRight = CheckNumberWithCeros(divisionsOfNumberID[0], aNumber);
                divisionsOfNumberID = divisionsOfNumberID[1].Split(tokens[1]);
                if (divisionsOfNumberID.Length == 2 && int.TryParse(divisionsOfNumberID[0], out aNumber) 
                    && int.TryParse(divisionsOfNumberID[1], out otherNumber)) {
                    numberIDRight = CheckNumberWithCeros(divisionsOfNumberID[1], aNumber) && CheckRangePositiveNumber(otherNumber,1);
                } else {
                    numberIDRight = false;
                }
            } else {
                numberIDRight = false;
            }
            return numberIDRight;
        }

        public bool CheckRangePositiveNumber (int number, int length) {
            return ((int)Math.Floor(Math.Log10(number)) + 1 == length) && number>0;
        }

        public bool IsTelephoneRight() {
            int result;
            return this.IsTelephoneBeginningRight() && this.Telephone.Length == 9
                && int.TryParse(this.Telephone.Substring(2), out result);
        }

        public bool IsTelephoneBeginningRight() {
            return this.Telephone[0] == '0' && this.Telephone[1] == '9';
        }

        public override string ToString() {
            StringBuilder clientData = new StringBuilder();
            clientData.Append(base.ToString());
            clientData.Append(" Number ID: ");
            clientData.Append(this.NumberID);
            clientData.Append(" Telephone: ");
            clientData.Append(this.Telephone);
            clientData.Append(" Address: ");
            clientData.Append(this.Address);
            return clientData.ToString();
        }
 
        public override bool Equals(object anObject)
        {
            Client aClient = anObject as Client;

            if (aClient == null)
                return false;

            return this.UserName.Equals(aClient.UserName) || (this.Name.Equals(aClient.Name) 
                && this.Surname.Equals(aClient.Surname)) || this.NumberID.Equals(aClient.NumberID) 
                || this.Telephone.Equals(aClient.Telephone) || this.Address.Equals(aClient.Address);
        }

        public override bool IsDesigner() { return false; }
        public override bool IsClient() { return true; }
        public override bool IsArchitect() { return false; }

    }
}
