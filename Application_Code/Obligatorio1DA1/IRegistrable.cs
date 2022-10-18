using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    public interface IRegistrable
    {

        bool IsWellRegistered();
        bool StoreData(SketchItApp program, IRegistrable userToEdit);
        void GetDataEditing(String[] dataEdited);
        void ChangePassword(SketchItApp program, String password);
        bool PasswordEquals(String otherPassword);
        String[] InitEditing(Form editingForm);

    }
}
