using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class HoleCreator : Form
    {

        private SketchItApp program;
        private IWindowsChangeable previousForm;
        private Graphics doorViewGraphic;
        private Graphics windowViewGraphic;
        private Door doorToView;
        private Window windowToView;

        public HoleCreator(SketchItApp programContinuation, IWindowsChangeable previousWindow)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.previousForm = previousWindow;
            InitializeWindow();
        }
        
        private void InitializeWindow()
        {
            this.doorViewGraphic = this.doorView.CreateGraphics();
            this.windowViewGraphic = this.windowView.CreateGraphics();
            this.doorToView = new Door(new Point(50,100));
            this.windowToView = new Window(new Point(50, 50));
            
        }

        private void RefreshDoorData() {
            this.doorNameTyped.Clear();
            this.doorLengthTyped.Clear();
            this.doorWidthTyped.Clear();
            this.doorHeightTyped.Clear();
        }

        private void RefreshWindowData() {
            this.windowNameTyped.Clear();
            this.windowLengthTyped.Clear();
            this.windowWidthTyped.Clear();
            this.windowHeightTyped.Clear();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create whatever Hole (Door and/or Window) you desire", "HOLE CREATOR");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                this.previousForm.ChangeToPreviousForm(this);
            }
        }

        private void NewDoor_Click(object sender, EventArgs e)
        {
            double[] doorDimensionsTyped = new double[3]; // {WIDTH, LENGTH, HEIGHT}
            String[] doorInputTyped = new String[] { this.doorNameTyped.Text, this.doorWidthTyped.Text, this.doorLengthTyped.Text, this.doorHeightTyped.Text };
            if(!this.IsInputBlanck(doorInputTyped) && (this.program.GetHoleFromHoleTypes(this.doorNameTyped.Text)==null) && this.IsInputNumber(ref doorDimensionsTyped) && this.IsInputCorrect(doorDimensionsTyped))
            {
                Door holeTypeToAdd = new Door(new Point(0, 0));
                holeTypeToAdd.Name = this.doorNameTyped.Text;
                holeTypeToAdd.SetActualSize(double.Parse(this.doorWidthTyped.Text), doorDimensionsTyped[1]);
                holeTypeToAdd.HeightFromFloor = doorDimensionsTyped[2];
                this.program.HoleTypes.Add(holeTypeToAdd);
                MessageBox.Show("New DOOR Created!");
                this.RefreshDoorData();
                this.doorToView = new Door(new Point(50, 100));
                this.doorView.Refresh();

            } else
            {
                MessageBox.Show("Failed to Create DOOR!!! \nRemember to Type a Name NOT yet Registered OR Blanks and Numbers as Width, Length and Height");
            }
        }

        public bool IsInputNumber(ref double[] holeInput)
        {
            bool inputDoorCorrect = double.TryParse(this.doorWidthTyped.Text, out holeInput[0]) && double.TryParse(this.doorLengthTyped.Text, out holeInput[1]) && double.TryParse(this.doorHeightTyped.Text, out holeInput[2]);
            bool inputWindowCorrect = double.TryParse(this.windowWidthTyped.Text, out holeInput[0]) && double.TryParse(this.windowLengthTyped.Text, out holeInput[1]) && double.TryParse(this.windowHeightTyped.Text, out holeInput[2]);
            return inputDoorCorrect || inputWindowCorrect;
        }

        public bool IsInputBlanck(String[] inputTyped)
        {
            return inputTyped[0].Equals("") || inputTyped[1].Equals("") || inputTyped[2].Equals("") || inputTyped[3].Equals("");
        }

        public bool IsInputCorrect(double[] holeInput)
        {
            return holeInput[0] <= 3 && holeInput[1] <= 2 && holeInput[1] + holeInput[2] <= 3;
        }

        private void NewWindow_Click(object sender, EventArgs e)
        {
            double[] windowDimensionsTyped = new double[3]; // {WIDTH, LENGTH, HEIGHT}
            String[] windowInputTyped = new String[] { this.windowNameTyped.Text, this.windowWidthTyped.Text, this.windowLengthTyped.Text, this.windowHeightTyped.Text };
            if (!this.IsInputBlanck(windowInputTyped) && (this.program.GetHoleFromHoleTypes(this.windowNameTyped.Text) == null) && this.IsInputNumber(ref windowDimensionsTyped) && this.IsInputCorrect(windowDimensionsTyped))
            {
                Window holeTypeToAdd = new Window(new Point(0, 0));
                holeTypeToAdd.Name = this.windowNameTyped.Text;
                holeTypeToAdd.SetActualSize(windowDimensionsTyped[0], windowDimensionsTyped[1]);
                holeTypeToAdd.HeightFromFloor = windowDimensionsTyped[2];
                this.program.HoleTypes.Add(holeTypeToAdd);
                MessageBox.Show("New WINDOW Created!");
                this.RefreshWindowData();
                this.windowToView = new Window(new Point(50, 50));
                this.windowView.Refresh();
            }
            else
            {
                MessageBox.Show("Failed to Create WINDOW!!! \nRemember to Type a Name NOT yet Registered OR Blanks and Numbers as Width, Length and Height");
            }
        }

        public bool ClosingProtocol()
        {
            if (this.Visible)
            {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT MaterialConfiguration", MessageBoxButtons.YesNo);
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

        private void HoleCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol()) {
                e.Cancel = true;
            }
        }

        private void DoorWidthTyped_TextChanged(object sender, EventArgs e)
        {
            double doorSize;
            if (double.TryParse(this.doorWidthTyped.Text, out doorSize) && doorSize>0 && doorSize<=3) {
                this.doorToView.Dimension.Width = (int)(doorSize * ConstantsDoor.BLOCKLENGTH);
                this.doorView.Refresh();
            }
        }

        private void WindowWidthTyped_TextChanged(object sender, EventArgs e)
        {
            double windowSize;
            if (double.TryParse(this.windowWidthTyped.Text, out windowSize) && windowSize>0 && windowSize<=3) {
                this.windowToView.Dimension.Width = (int)(windowSize * ConstantsDoor.BLOCKLENGTH);
                this.windowView.Refresh();
            }
        }

        private void DoorView_Paint(object sender, PaintEventArgs e)
        {
            this.doorViewGraphic.Clear(Color.White);
            this.doorToView.Draw(ref this.doorViewGraphic);
        }

        private void WindowView_Paint(object sender, PaintEventArgs e)
        {
            this.windowViewGraphic.Clear(Color.White);
            this.windowToView.Draw(ref this.windowViewGraphic);
        }
    }
}
