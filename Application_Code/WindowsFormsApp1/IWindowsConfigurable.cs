using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public interface IWindowsConfigurable
    {
        void InitializeWindow();
        void ChangeWindowForm(Form previousForm, Form nextForm);
        bool ClosingProtocol();
    }
}
