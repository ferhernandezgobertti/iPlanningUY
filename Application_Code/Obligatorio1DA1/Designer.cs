using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Domain
{
    
    public class Designer : Worker, ILoggable
    {

        public int ChartsHelped { get; set; }
        public int ClientsHelped { get; set; }

        public Designer() {
            this.ChartsHelped = 0;
            this.ClientsHelped = 0;
        }

        public override void AddChartsHelped(ref SketchItApp currentProgram) {
            currentProgram.GetDesignerFromList(this).ChartsHelped++;
        }

        public override void AddClientsHelped(ref SketchItApp currentProgram) {
            currentProgram.GetDesignerFromList(this).ClientsHelped++;
        }

        public override bool StoreData(SketchItApp program, IRegistrable designerForList) {
            bool correctSearch = false;
            var index = program.Users.IndexOf(program.GetDesignerFromList(this));
            if (correctSearch = (index != -1)) {
                program.Users[index] = (Designer)designerForList;
            }
            return correctSearch;
        }

        public override void ChangePassword(SketchItApp program, String newPassword) {
            program.GetDesignerFromList(this).Password = newPassword;
        }

        public ILoggable CheckLogIn(SketchItApp program, String username, String password) {
            Designer designerTyped = new Designer();
            designerTyped.UserName = username;
            designerTyped.Password = password;
            Designer designerFound = new Designer();
            if (((designerFound = program.GetDesignerFromList(designerTyped)) != null) && designerFound.IsPasswordCorrect(password))
            {
                program.GetDesignerFromList(designerFound).UpdateLastEntry();
                return designerFound;
            } else {
                return null;
            }
        }

        public override bool IsDesigner() { return true; }
        public override bool IsClient() { return false; }
        public override bool IsArchitect() { return false; }

    }
}
