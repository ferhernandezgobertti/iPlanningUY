using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GUI.Exceptions;
using DataAccess;

namespace GUI
{
    public partial class MenuDesigner : Form, IWindowsChangeable
    {
        private SketchItApp program;
        private Designer designerLogged;
        private ChartDataAccess chartContext = new ChartDataAccess();
        public MenuDesigner(SketchItApp programContinuation, Designer currentDesigner)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.designerLogged = currentDesigner;
            InitializeWindow();
            if (this.program.Charts.Count != 0)
            {
                this.chartsListed.DrawMode = DrawMode.OwnerDrawFixed;
                this.chartsListed.DrawItem += new DrawItemEventHandler(this.ChartsListed_DrawItem);
            }
        }

        public void InitializeWindow()
        {
            this.FillChartsList(this.program.Charts);
            this.FillClientsList(this.program.GetClientsFromUsers());
            this.designerData.Text = this.UserDataCompletion(this.program.GetDesignerFromList(designerLogged).ChartsHelped, this.program.GetDesignerFromList(designerLogged).ClientsHelped);
        }

        private void FillChartsList(List<IChartable> chartsForListBox)
        {
            if (chartsForListBox.Count == 0)
            {
                this.chartsListed.Items.Clear();
                this.chartsListed.Items.Add(string.Join(Environment.NewLine, "NO CHARTS Constructed Yet"));
            }
            else
            {
                this.chartsListed.Items.Clear();

                FillElementsOnChart(program.Charts);
                foreach (Chart someChart in chartsForListBox) {
                    chartsListed.Items.Add(someChart);
                }
            }
        }

        private void FillElementsOnChart(List<IChartable> chartsToAddElements)
        {
            
            foreach (Chart chartToAddElements in chartsToAddElements)
            {
                chartToAddElements.Elements = chartContext.GetElementsOfChart(chartToAddElements);
            }

        }

        private void FillClientsList(List<IUserable> clientsForListBox)
        {
            if (clientsForListBox.Count == 0)
            {
                this.clientsListed.Items.Clear();
                this.clientsListed.Items.Add(string.Join(Environment.NewLine, "NO CLIENTS registered Yet. Ask Admin to Register Client"));
            }
            else
            {
                this.clientsListed.Items.Clear();
                foreach (Client someClient in clientsForListBox)
                {
                    clientsListed.Items.Add(someClient);
                }
            }
        }

        public bool ClosingProtocol()
        {
            if (this.Visible)
            {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT MenuDesigner", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            } else
            {
                return true;
            }
        }

        public void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        public void ChangeToPreviousForm(Form currentForm)
        {
            currentForm.Visible = false;
            this.Refresh();
            this.Visible = true;
        }

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart) {
            ChangeToPreviousForm(currentForm);
        }

        private String UserDataCompletion(int chartsQuantity, int clientsQuantity)
        {
            StringBuilder userData = new StringBuilder();
            userData.Append("YOUR DATA:      Username: ");
            userData.Append(this.designerLogged.UserName);
            userData.Append("\nName: ");
            userData.Append(this.designerLogged.Name);
            userData.Append("     Surname: ");
            userData.Append(this.designerLogged.Surname);
            userData.Append("\nRegistration: ");
            userData.Append(this.designerLogged.Registration);
            userData.Append("\nLast Entry: ");
            userData.Append(this.designerLogged.LastEntry);
            userData.Append("\nCHARTS AIDED: ");
            userData.Append(chartsQuantity);
            userData.Append(" CLIENTS HELPED w/NEW CHARTS: ");
            userData.Append(clientsQuantity);
            return userData.ToString();
        }

        private void MenuDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create a new Chart, Modify an old Chart or Delete a Chart!" +
                "\nYou can also Change your Password", "MENU DESIGNER");
        }

        private void LogOutOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Log Out?", "EXIT", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new LogIn(this.program));
            }
        }

        private void CheckPreviousClientSelection()
        {
            if(this.clientsListed.SelectedItem == null)
            {
                throw new NoClientSelectedException();
            }
        }

        private void NewChart_Click(object sender, EventArgs e)
        {
            try
            {
                CheckPreviousClientSelection();
                Client clientSelected = this.program.GetClientFromList((Client)this.clientsListed.SelectedItem);
                Chart newChart = new Chart(this.designerLogged, clientSelected);
                chartContext.AddChart(newChart);
                ChangeWindowForm(this, new ChartConfiguration(this.program, newChart, this.designerLogged, this));
            }
            catch (NoClientSelectedException)
            {
                MessageBox.Show("Please, first select a Client and then choose the Option CREATE Chart");
            }
        }

        private void CheckPreviousUnsignedChartSelection()
        {
            bool previouslySelected = this.chartsListed.SelectedItem != null && !this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).IsSigned();
            if (!previouslySelected)
            {
                throw new NoUnsignedChartSelectedException();
            }
        }

        private void ModifyChart_Click(object sender, EventArgs e)
        {
            try {
                CheckPreviousUnsignedChartSelection();
                Chart chartSelected = this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem);
                chartSelected.Dimensions = chartContext.GetChart(chartSelected).Dimensions;
                
                ChangeWindowForm(this, new ChartDrawing(this.program, chartSelected, this.designerLogged, this));
            }
            catch (NoUnsignedChartSelectedException)
            {
                MessageBox.Show("Please, first select an UNSIGNED CHART and then choose the Option MODIFY Chart");
            }
        }

        private void EraseChart_Click(object sender, EventArgs e)
        {
            try {
                CheckPreviousUnsignedChartSelection();
                this.program.Charts.Remove((Chart)this.chartsListed.SelectedItem);
                chartContext.RemoveChart((Chart)this.chartsListed.SelectedItem);
                MessageBox.Show("Chart SUCCESFULLY Erased!");
                ChangeWindowForm(this, new MenuDesigner(this.program, this.designerLogged)); //Problem with this.Refresh()
            }
            catch (NoUnsignedChartSelectedException)
            {
                MessageBox.Show("Please, first select an UNSIGNED CHART and then choose the Option ERASE Chart");
            }
        }

        private void PasswordChange_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new PasswordEditing(this.program, this.designerLogged, this));
        }

        private void CheckIfChartToShowSelected()
        {
            if (this.chartsListed.SelectedItem == null)
            {
                throw new NoChartToShowSelectedException();
            }
        }

        private void ShowChart_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIfChartToShowSelected();
                Chart chartSelected = this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem);
                ChangeWindowForm(this, new ChartShowing(this.program, chartSelected, this));
            }
            catch(NoChartToShowSelectedException)
            {
                MessageBox.Show("Please, first select a Chart and then choose the Option SHOW Chart");
            }
        }

        private void ChartsListed_MouseClick(object sender, MouseEventArgs e)
        {
            this.clientsListed.ClearSelected();
        }

        private void ClientsListed_MouseClick(object sender, MouseEventArgs e)
        {
            this.chartsListed.ClearSelected();
        }

        private void ChartsListed_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Chart chartToGet = (this.program.GetChartFromList((Chart)this.chartsListed.Items[e.Index]));
            SolidBrush itemBrush = new SolidBrush(Color.Black);
            if (this.chartsListed.Items.Count != 0 && chartToGet!=null) {
                if (chartToGet.IsSigned())
                {
                    itemBrush = new SolidBrush(Color.Red);
                }
                e.Graphics.DrawString(this.chartsListed.Items[e.Index].ToString(), e.Font, itemBrush, e.Bounds);
            }
        }

        private void MenuDesigner_VisibleChanged(object sender, EventArgs e)
        {
            InitializeWindow();
        }

        private void HoleCreate_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new HoleCreator(this.program, this));
        }
    }
}
