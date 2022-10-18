using Domain;
using System;
using System.Windows.Forms;

namespace GUI
{
    public interface IWindowsChangeable
    {
        void ChangeToPreviousForm(Form currentForm);
        void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart);
    }
}
