using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Domain
{
  
    public class Worker : User, IRegistrable
    {

        public bool IsWellRegistered()
        {
            return this.IsPasswordRight() && this.UserName.Length <= 13 && this.UserName.Length >= 4
                && !this.IsWordWithSymbol(this.Name, " ") && !this.IsWordWithSymbol(this.Surname, " ");
        }

        public String[] InitEditing(Form editingForm)
        {
            editingForm.Size = new Size(editingForm.Size.Width, 375);
            String[] workerData = { this.UserName, this.Name, this.Surname, "", "", "" };
            return workerData;
        }

        public void GetDataEditing(String[] userData)
        {
            this.UserName = userData[0];
            this.Name = userData[1];
            this.Surname = userData[2];
        }

        public bool PasswordEquals(String newPassword)
        {
            return this.Password.Equals(newPassword);
        }

        public virtual bool StoreData(SketchItApp program, IRegistrable userToEdit) {
            return true;
        }

        public virtual void ChangePassword(SketchItApp program, String password) { }

        public virtual void AddChartsHelped(ref SketchItApp currentProgram) { }
        public virtual void AddClientsHelped(ref SketchItApp currentProgram) { }

        public override bool Equals(object anObject) {
            Worker aWorker = anObject as Worker;

            if (aWorker == null)
                return false;

            return this.UserName.Equals(aWorker.UserName) || (this.Name.Equals(aWorker.Name) && this.Surname.Equals(aWorker.Surname));
        }


    }
}
