using DataAccess;
using Domain;
using GUI.Exceptions;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChartConfiguration : Form, IWindowsChangeable
    {
        private SketchItApp program;
        private Chart chartToConfigure;
        private Worker currentUser;
        private IWindowsChangeable previousForm;
        public ChartConfiguration(SketchItApp programContinuation, Chart currentChart, Worker configurationUser, IWindowsChangeable previousWindow)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.chartToConfigure = currentChart;
            this.currentUser = configurationUser;
            this.previousForm = previousWindow;
            this.nameTyped.MaxLength = 10;
        }

        public String[] InitEditing(Form editingForm)
        {
            return null;
        }

        public void ChangeToPreviousForm(Form currentForm) {
            currentForm.Visible = false;
            this.Refresh();
            this.Visible = true;
        }

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart) {
            ChangeToPreviousForm(currentForm);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int[] dimensionsEntered = new int[2];
                this.chartToConfigure.Name = this.nameTyped.Text;
                if ((dimensionsEntered = this.CheckChartDimensions()) != null) {
                    this.chartToConfigure.Dimensions.Width = dimensionsEntered[0];
                    this.chartToConfigure.Dimensions.Length = dimensionsEntered[1];
                    CheckIfChartWellRegistered(this.chartToConfigure);
                    ChartDataAccess chartContext = new ChartDataAccess();
                    chartContext.ConfigurationOfChart(this.chartToConfigure,this.chartToConfigure.Name, this.chartToConfigure.Dimensions);
                    MessageBox.Show("Chart SUCCESFULLY Created!");
                    ChangeWindowForm(this, new ChartDrawing(this.program, this.chartToConfigure, this.currentUser, this.previousForm));
                }
            }
            catch (ChartConfigureException) {
                MessageBox.Show("Check Parameteres typed.\nYour Chart's Name should be unique and each dimension should be less or equal than 100 metres.");
                this.nameFailure.Text = "NAME FAILED: Repeated or Wrongly Taped (please NO SPACES). Choose another one.";
                this.lengthFailure.Text = "LENGTH FAILED: Integer <= 100 needed";
                this.widthFailure.Text = "WIDTH FAILED: Integer <= 100 needed";
            }
        }

        private void CheckIfChartWellRegistered(Chart chartToRegister)
        {
            if (!chartToRegister.IsChartWellRegistered()) {
                throw new ChartConfigureException();
            }
        }

        private int[] CheckChartDimensions() {
            int[] dimensionsOutput = new int[2];
            if (int.TryParse(this.lengthTyped.Text, out dimensionsOutput[1]) && int.TryParse(this.widthTyped.Text, out dimensionsOutput[0])) {
                return dimensionsOutput;
            } else {
                this.lengthFailure.Text = "LENGTH FAILED: No Integer Number typed";
                this.widthFailure.Text = "WIDTH FAILED: No Integer Number typed";
                return null;
            }   
        }

        private bool IsDimensionCorrect(int[] dimensionsOfChart) {
            this.chartToConfigure.Dimensions.Width = dimensionsOfChart[0];
            this.chartToConfigure.Dimensions.Length = dimensionsOfChart[1];
            return this.chartToConfigure.IsChartWellRegistered();
        }

        private bool ClosingProtocol()
        {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT ChartConfiguration", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            }
            else {
                return true;
            }
        }

        private void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        private void ChartConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void Help_Click(object sender, EventArgs e) {
            MessageBox.Show("Configure your new Chart parameters. Length and Width MUST BE less or equal than 100 metres");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                this.previousForm.ChangeToPreviousForm(this);
            }
        }
    }
}
