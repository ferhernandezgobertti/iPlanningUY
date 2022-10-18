using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{

    public partial class MenuClient : Form, IWindowsChangeable
    {
        private SketchItApp program;
        private Client clientLogged;
        private bool noSignedChartsToShow;
        private bool noUnsignedChartsToShow;
        public MenuClient(SketchItApp programContinuation, Client currentClient)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.clientLogged = currentClient;
            this.noUnsignedChartsToShow = true;
            this.noUnsignedChartsToShow = true;
            InitializeWindow();
            this.signedChartsListed.DrawMode = DrawMode.OwnerDrawFixed;
            this.signedChartsListed.DrawItem += new DrawItemEventHandler(this.SignedChartsListed_DrawItem);
        }

        public void InitializeWindow()
        {
            List<IChartable> chartsFromClient = program.GetChartsFromClient(this.clientLogged);
            this.FillUnsignedChartList(chartsFromClient);
            List<Chart> chartsWithSingleSignatures = program.DivideChartIntoSingleSignatures(chartsFromClient);
            this.FillSignedChartList(chartsWithSingleSignatures);
            this.clientData.Text = this.ClientDataCompletion(this.program.GetChartsFromClient(clientLogged).Count);
        }

        public void ChangeToPreviousForm(Form currentForm)
        {
            currentForm.Visible = false;
            this.Refresh();
            this.Visible = true;
        }

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart)
        {
            ChangeToPreviousForm(currentForm);
        }

        private void FillUnsignedChartList(List<IChartable> chartsForListBox) {
            this.unsignedChartsListed.Items.Clear();
            if (chartsForListBox.Count == 0) {
                this.noUnsignedChartsToShow = true;
                this.unsignedChartsListed.Items.Add(string.Join(Environment.NewLine, "NO CHARTS Made For You Yet"));
            } else {
                this.noUnsignedChartsToShow = false;
                foreach (Chart someChart in chartsForListBox) {
                    this.program.GetChartFromList(someChart).Money.Cost = this.program.CalculateCostAndPrice(someChart)[0];
                    this.program.GetChartFromList(someChart).Money.Price = this.program.CalculateCostAndPrice(someChart)[1];
                    if (!this.program.GetChartFromList(someChart).IsSigned()) {
                        unsignedChartsListed.Items.Add(someChart);
                    }
                }
                
            }
        }

        private void FillSignedChartList(List<Chart> chartsForListBox) {
            this.signedChartsListed.Items.Clear();
            if (chartsForListBox.Count == 0) {
                this.noSignedChartsToShow = true;
                this.signedChartsListed.Items.Add(string.Join(Environment.NewLine, "NO CHARTS Signed For You Yet"));
            } else {
                this.noSignedChartsToShow = false;
                foreach (Chart someChart in chartsForListBox) {  
                    if (someChart.IsSigned() || someChart.IsCompletelySigned()) {
                        signedChartsListed.Items.Add(someChart);
                    }
                }
                
            }
        }

        private String ClientDataCompletion(int chartsQuantity)
        {
            StringBuilder clientData = new StringBuilder();
            clientData.Append("YOUR DATA:      Username: ");
            clientData.Append(this.clientLogged.UserName);
            clientData.Append("\nName: ");
            clientData.Append(this.clientLogged.Name);
            clientData.Append("     Surname: ");
            clientData.Append(this.clientLogged.Surname);
            clientData.Append("\nRegistration: ");
            clientData.Append(this.clientLogged.Registration);
            clientData.Append("\nLast Entry: ");
            clientData.Append(this.clientLogged.LastEntry);
            clientData.Append("\nCHARTS REQUESTED: ");
            clientData.Append(chartsQuantity);
            return clientData.ToString();
        }


        public bool ClosingProtocol()
        {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT MenuClient", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            } else {
                return true;
            }
        }

        public void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        private void MenuClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void HelpClient_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a Chart to watch it and download it as Image (JPG, JPEG)", "MENU CLIENT");
        }

        private void PasswordChange_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new PasswordEditing(this.program, this.clientLogged, this));
        }

        private void LogOutOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Log Out?", "EXIT", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new LogIn(this.program));
            }
        }

        private void SelectChart_Click(object sender, EventArgs e)
        {
            if(!IsChartSelected()) {
                MessageBox.Show("Please, first select a Chart and then click on Select");
            }
        }

        private bool IsChartSelected()
        {
            bool unsignedChartSelected = (this.unsignedChartsListed.SelectedItem != null);
            bool signedChartSelected = (this.signedChartsListed.SelectedItem != null);
            if (unsignedChartSelected) {
                Chart chartSelected = this.program.GetChartFromList((Chart)this.unsignedChartsListed.SelectedItem);
                ChangeWindowForm(this, new ChartShowing(this.program, chartSelected, this));
            }
            if (signedChartSelected) {
                Chart chartSelected = this.program.GetChartFromList((Chart)this.signedChartsListed.SelectedItem);
                ChangeWindowForm(this, new ChartShowing(this.program, chartSelected, this));
            }
            return unsignedChartSelected || signedChartSelected;
        }

        private void SignedChartsListed_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush itemBrush = new SolidBrush(Color.Green);
            if (this.signedChartsListed.Items.Count != 0 && !this.noSignedChartsToShow) {
                if (this.program.GetChartFromList((Chart)this.signedChartsListed.Items[e.Index]).IsSigned()) {
                    itemBrush = new SolidBrush(Color.Red);
                }
                e.Graphics.DrawString(this.DetermineChartInformation(this.program.GetChartFromList((Chart)this.signedChartsListed.Items[e.Index])), e.Font, itemBrush, e.Bounds);
            }
        }

        private String DetermineChartInformation (Chart chartToDetermine) {
            StringBuilder chartInfo = new StringBuilder();
            bool isChartSigned = this.program.GetChartFromList(chartToDetermine).IsSigned();
            bool isChartCompletelySigned = this.program.GetChartFromList(chartToDetermine).IsCompletelySigned();
            if (isChartSigned) {
                chartInfo.Append("FIRST SIGNATURE - ");
            }
            if (isChartCompletelySigned) {
                chartInfo.Append("SECOND SIGNATURE - ");
            }
            chartInfo.Append(chartToDetermine.ToString());
            chartInfo.Append(chartToDetermine.Signatures[0].ToString());
            return chartInfo.ToString();
        }

        private void SignedChartsListed_Click(object sender, EventArgs e)
        {
            this.unsignedChartsListed.ClearSelected();
        }

        private void UnsignedChartsListed_Click(object sender, EventArgs e)
        {
            this.signedChartsListed.ClearSelected();
        }
    }
}
