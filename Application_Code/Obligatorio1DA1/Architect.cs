using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
  
    public class Architect: Worker, ILoggable {
        public int ChartsSigned { get; set; }

        public Architect() {
            this.ChartsSigned = 0;
        }

        public override bool StoreData(SketchItApp program, IRegistrable architectForList)
        {
            bool correctSearch = false;
            var index = program.Users.IndexOf(program.GetArchitectFromList(this));
            if (correctSearch = (index != -1))
            {
                program.Users[index] = (Architect)architectForList;
            }
            return correctSearch;
        }

        public override void ChangePassword(SketchItApp program, String newPassword)
        {
            program.GetArchitectFromList(this).Password = newPassword;
        }

        public ILoggable CheckLogIn(SketchItApp program, String username, String password) {
            Architect architectTyped = new Architect();
            architectTyped.UserName = username;
            architectTyped.Password = password;
            Architect architectFound = new Architect();
            if (((architectFound = program.GetArchitectFromList(architectTyped)) != null) && architectFound.IsPasswordCorrect(password)) {
                program.GetArchitectFromList(architectFound).UpdateLastEntry();
                return architectFound;
            } else {
                return null;
            }
        }

        public override bool IsDesigner() { return false; }
        public override bool IsClient() { return false; }
        public override bool IsArchitect() { return true; }

    }
}