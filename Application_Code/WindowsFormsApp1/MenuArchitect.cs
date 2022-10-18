using System;
using Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Exceptions;
using DataAccess;

namespace GUI
{
    public partial class MenuArchitect : Form, IWindowsChangeable
    {
        private SketchItApp program;
        private Architect architectLogged;
        private ChartDataAccess chartContext = new ChartDataAccess();
        public MenuArchitect(SketchItApp programContinuation, Architect currentArchitect)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.architectLogged = currentArchitect;
            
            InitializeWindow();
        }

        public void InitializeWindow() {
            this.FillChartsList(this.program.Charts);
            List<Chart> chartsWithSingleSignatures = program.DivideChartIntoSingleSignatures(this.program.Charts);
            this.FillSignedChartsList(chartsWithSingleSignatures);
            this.architectData.Text = this.UserDataCompletion(this.program.GetArchitectFromList(architectLogged).ChartsSigned);
            this.FillDomainUpDown();
            if (this.program.Charts.Count != 0)
            {
                this.chartsListed.DrawMode = DrawMode.OwnerDrawFixed;
                this.chartsListed.DrawItem += new DrawItemEventHandler(this.ChartsListed_DrawItem);
                this.signedChartsListed.DrawMode = DrawMode.OwnerDrawFixed;
                this.signedChartsListed.DrawItem += new DrawItemEventHandler(this.SignedChartsListed_DrawItem);
            } else
            {
                this.chartsListed.DrawMode = DrawMode.Normal;
                this.signedChartsListed.DrawMode = DrawMode.Normal;
            }
        }

        private void FillDomainUpDown() {
            DomainUpDown.DomainUpDownItemCollection clientsCollection = this.clientsOfProgram.Items;
            clientsCollection.Add("ALL CLIENTS");
            foreach (Client programClient in this.program.GetClientsFromUsers()) {
                clientsCollection.Add(programClient.UserName);
            }
            this.clientsOfProgram.Text = "Select Client";
        }

        private void FillChartsList(List<IChartable> chartsForListBox) {
            if (chartsForListBox.Count == 0) {
                this.chartsListed.Items.Clear();
                this.chartsListed.Items.Add(string.Join(Environment.NewLine, "NO CHARTS Constructed Yet"));
            } else {
                this.chartsListed.Items.Clear();
                foreach (Chart someChart in chartsForListBox) {
                    chartsListed.Items.Add(someChart);
                }
            }
        }

        private void FillSignedChartsList(List<Chart> chartsForListBox) {
            if (chartsForListBox.Count == 0) {
                this.signedChartsListed.Items.Clear();
                this.signedChartsListed.Items.Add(string.Join(Environment.NewLine, "NO CHARTS Signed Yet"));
            } else {
                this.signedChartsListed.Items.Clear();
                foreach (Chart someChart in chartsForListBox) {
                    if (someChart.IsCompletelySigned()) {
                        signedChartsListed.Items.Add(someChart);
                    }
                }
            }
        }

        private String UserDataCompletion(int signedChartsQuantity) {
            StringBuilder userData = new StringBuilder();
            userData.Append("YOUR DATA:      Username: ");
            userData.Append(this.architectLogged.UserName);
            userData.Append("     Name: "); //CHANGED!!!
            userData.Append(this.architectLogged.Name);
            userData.Append("     Surname: ");
            userData.Append(this.architectLogged.Surname);
            userData.Append("\nRegistration: ");
            userData.Append(this.architectLogged.Registration);
            userData.Append("\nLast Entry: ");
            userData.Append(this.architectLogged.LastEntry);
            userData.Append("\nCHARTS SIGNED: ");
            userData.Append(signedChartsQuantity);
            return userData.ToString();
        }

        private void NewChart_Click(object sender, EventArgs e)
        {
            if (this.clientsOfProgram.SelectedIndex != -1)
            {
                Client clientSelected = (Client)this.program.GetClientsFromUsers().ElementAt(this.clientsOfProgram.SelectedIndex-1);
                Chart newChart = new Chart(this.architectLogged, clientSelected);
                ChartDataAccess chartContext = new ChartDataAccess();
                chartContext.AddChart(newChart);
                ChangeWindowForm(this, new ChartConfiguration(this.program, newChart, this.architectLogged, this));
            }
            else
            {
                MessageBox.Show("Please, first select a Client and then choose the Option CREATE Chart");
            }
        }

        private void CheckPreviousSignedChartSelection()
        {

            bool previouslySelected = this.chartsListed.SelectedItem != null && this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).IsSigned();
            if (!previouslySelected)
            {
                throw new NoSignedChartSelectedException();
            }
        }

        private void ModifyChart_Click(object sender, EventArgs e)
        {
            try
            {
                //CheckPreviousSignedChartSelection();
                Chart chartSelected = this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem);
                chartSelected.Dimensions = chartContext.GetChart(chartSelected).Dimensions;
                ChangeWindowForm(this, new ChartDrawing(this.program, chartSelected, this.architectLogged, this));
            }
            catch(NoSignedChartSelectedException)
            {
                MessageBox.Show("Please, first select a SIGNED CHART and then choose the Option MODIFY Chart");
            }
        }

        private void EraseChart_Click(object sender, EventArgs e)
        {
            try
            {
                //CheckPreviousSignedChartSelection();
                this.program.Charts.Remove((Chart)this.chartsListed.SelectedItem);
                chartContext.RemoveChart((Chart)this.chartsListed.SelectedItem);
                MessageBox.Show("Chart SUCCESFULLY Erased!");
                InitializeWindow(); //Problem with this.Refresh()
            }
            catch(NoSignedChartSelectedException)
            {
                MessageBox.Show("Please, first select a SIGNED CHART and then choose the Option ERASE Chart");
            }
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

        private void SignChart_Click(object sender, EventArgs e)
        {
            
            if (this.chartsListed.SelectedItem != null && !this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).IsSigned()) {
                Signature newSignature = new Signature(this.architectLogged);
                this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).Signatures.Add(newSignature);
                this.program.GetArchitectFromList(this.architectLogged).ChartsSigned++;
                //chartContext.AddSignatureToChart((Chart)this.chartsListed.SelectedItem, newSignature);
                InitializeWindow();
            } else
            {
                if(this.chartsListed.SelectedItem != null && this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).IsSigned())
                {
                    this.program.AddChartsSigned(this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem), this.architectLogged);
                    this.program.GetChartFromList((Chart)this.chartsListed.SelectedItem).GetSignatureWithOneSigning().RegisterSecondSignature(this.architectLogged);
                    InitializeWindow();
                }
            }
        }

        private void ChartsListed_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush itemBrush = new SolidBrush(Color.Black);
            Chart currentChart = this.program.GetChartFromList((Chart)this.chartsListed.Items[e.Index]);
            if (this.chartsListed.Items.Count != 0 && currentChart!=null && currentChart.IsSigned()) {
                itemBrush = new SolidBrush(Color.Red);
            }
            e.Graphics.DrawString(this.chartsListed.Items[e.Index].ToString(), e.Font, itemBrush, e.Bounds);
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

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart)
        {
            DialogResult signChart = MessageBox.Show("Do you want to Sign this Chart given that it has been Modified?", "BACK", MessageBoxButtons.YesNo);
            if (signChart == DialogResult.Yes) {
                this.program.AddChartsSigned(this.program.GetChartFromList(currentChart), this.architectLogged);
                this.program.GetChartFromList(currentChart).GetSignatureWithOneSigning().RegisterSecondSignature(this.architectLogged);
            }
            ChangeToPreviousForm(currentForm);
        }

        private void LogOutOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Log Out?", "EXIT", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new LogIn(this.program));
            }
        }

        private void PasswordChange_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new PasswordEditing(this.program, this.architectLogged, this));
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a Chart to sign it or watch it and download it as Image.\n" +
                " Also, Create a new Chart, Modify an old Chart or Delete a Chart!" +
                "\nYou can also Change your Password", "MENU ARCHITECT");
        }

        private void ClientsOfProgram_SelectedItemChanged(object sender, EventArgs e)
        {
            List<IChartable> filteredCharts = new List<IChartable>();
            if (this.clientsOfProgram.SelectedIndex > (this.program.GetClientsFromUsers().Count))
                this.clientsOfProgram.SelectedIndex = 0;
            if (this.clientsOfProgram.SelectedIndex == 0) {
                filteredCharts = this.program.Charts;
            }
            if(this.clientsOfProgram.SelectedIndex>0){ 
                filteredCharts = this.program.GetChartsFromClient((Client)this.program.GetClientsFromUsers().ElementAt(this.clientsOfProgram.SelectedIndex-1));
            }
            if (filteredCharts.Count == 0)
            {
                this.chartsListed.Items.Clear();
            } else { 
                this.FillChartsList(filteredCharts);
                List<Chart> chartsWithSingleSignatures = program.DivideChartIntoSingleSignatures(filteredCharts);
                this.FillSignedChartsList(chartsWithSingleSignatures);
                //this.FillSignedChartsList(this.program.Charts);
            }
        }

        private void MenuArchitect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        public bool ClosingProtocol()
        {
            if (this.Visible)
            {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT MenuArchitect", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            }
            else
            {
                return true;
            }
        }

        private void SignedChartsListed_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush itemBrush = new SolidBrush(Color.Green);
            if (this.signedChartsListed.Items.Count != 0) {
                Chart chartToCheck = (Chart)this.signedChartsListed.Items[e.Index];
                StringBuilder chartInfo = new StringBuilder();
                chartInfo.Append(DetermineChartInformation(this.program.GetChartFromList(chartToCheck)));
                chartInfo.Append(chartToCheck.Signatures[0].ToString());
                e.Graphics.DrawString(chartInfo.ToString(), e.Font, itemBrush, e.Bounds);
            }
        }

        private String DetermineChartInformation(Chart chartToDetermine)
        {
            StringBuilder infoDetermined = new StringBuilder();
            infoDetermined.Append("CHART NAME: ");
            infoDetermined.Append(chartToDetermine.Name);
            infoDetermined.Append(" :: CREATOR: ");
            infoDetermined.Append(chartToDetermine.UserCreator.UserName);
            infoDetermined.Append(" - Length: ");
            infoDetermined.Append(chartToDetermine.Dimensions.Width);
            infoDetermined.Append(" - Width: ");
            infoDetermined.Append(chartToDetermine.Dimensions.Length);
            infoDetermined.Append(" - Cost: ");
            infoDetermined.Append(chartToDetermine.Money.Cost);
            infoDetermined.Append(" - Price: ");
            infoDetermined.Append(chartToDetermine.Money.Price);
            return infoDetermined.ToString();
        }

        private void MenuArchitect_VisibleChanged(object sender, EventArgs e)
        {
            InitializeWindow();
        }

        private void ChartsListed_Click(object sender, EventArgs e)
        {
            this.signedChartsListed.ClearSelected();
        }

        private void SignedChartsListed_Click(object sender, EventArgs e)
        {
            this.chartsListed.ClearSelected();
        }

        private void HoleCreate_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new HoleCreator(this.program, this));
        }

        private void MenuArchitect_Load(object sender, EventArgs e)
        {

        }
    }
}
