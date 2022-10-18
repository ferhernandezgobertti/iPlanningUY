using System;
using System.Text;

namespace Domain
{
    
    public class Administrator : User, ILoggable
    {
        //public int Cost { get; set; }
        //public int Price { get; set; }
        public Administrator() : base()
        {
            this.Name = "adminSketchIt";
            this.Surname = "adminSketchIt";
            this.UserName = "admin";
            this.Password = "admin2018";
        }

        public new bool IsPasswordRight()
        {
            return this.Password.Equals("admin2018");
        }

        public new bool IsUserNameRight()
        {
            return this.UserName.Equals("admin");
        }

        public ILoggable CheckLogIn(SketchItApp program, String username, String password) {
            Administrator adminTyped = new Administrator();
            adminTyped.UserName = username;
            adminTyped.Password = password;
            if (adminTyped.Equals(this))
            {
                program.Admin.UpdateLastEntry();
                return this;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder adminData = new StringBuilder();
            adminData.Append(base.ToString());
            return adminData.ToString();
        }

    }
}
