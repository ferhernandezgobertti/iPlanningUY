using Domain;
using GUI.Exceptions;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace GUI
{

    public partial class ChartDrawing : Form
    {
        private SketchItApp program;
        private Chart drawingChart;
        private Worker currentUser;
        private IWindowsChangeable previousForm;

        private Door doorChosen;
        private Window windowChosen;

        private Graphics chartGraphic;
        private Graphics doorGraphic;
        private Graphics windowGraphic;
        private Graphics columnGraphic;

        private Point? initialPoint;

        private bool isDoorSelected;
        private bool isWindowSelected;
        private bool isColumnSelected;
        private bool isChartModified;
        private bool isRemoveLineSelected;
        private bool isRemoveHoleSelected;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public ChartDrawing(SketchItApp programContinuation, Chart workingChart, Worker drawingUser, IWindowsChangeable previousWindow) {
            InitializeComponent();
            this.program = programContinuation;
            this.drawingChart = workingChart;
            this.currentUser = drawingUser;
            this.previousForm = previousWindow;
            SetParent(this.chartDraw.Handle, this.backPanel.Handle);
            this.chartDraw.Size = new Size(this.drawingChart.GetPixels()[0] + 2*ConstantsChart.BLOCKPIXELS, this.drawingChart.GetPixels()[1] + 2*ConstantsChart.BLOCKPIXELS);
            InitializeWindow();
        }

        public void InitializeWindow() {
            this.DefineGraphics();
            this.InitializeTitle();
            this.InitializeHoles();
            this.ConfigureGridStyleCheckBox();
            this.FillDoorTypesOptions();
            this.FillWindowTypesOptions();
        }

        private void DefineGraphics() {
            this.chartGraphic = this.chartDraw.CreateGraphics();
            this.chartGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.doorGraphic = this.door.CreateGraphics();
            this.windowGraphic = this.window.CreateGraphics();
            this.columnGraphic = this.column.CreateGraphics();
            this.isChartModified = false;
        }

        private void InitializeTitle() {
            StringBuilder titleBuilder = new StringBuilder();
            titleBuilder.Append("CHART: ");
            titleBuilder.Append(this.drawingChart.Name);
            this.titleChart.Text = titleBuilder.ToString();
        }

        private void InitializeHoles() {
            this.doorChosen = new Door(new Point(0, 0));
            this.windowChosen = new Window(new Point(0, 0));
            this.isDoorSelected = false;
            this.isWindowSelected = false;
            this.isColumnSelected = false;
            this.isRemoveLineSelected = false;
            this.isRemoveHoleSelected = false;
        }

        private void ConfigureGridStyleCheckBox() {
            this.differentStylesOptions.Items.Add("Solid Grid", true);
            this.differentStylesOptions.Items.Add("Dashed Grid", false);
            this.differentStylesOptions.Items.Add("Invisible Grid", false);
            this.differentStylesOptions.CheckOnClick = true;
            this.differentStylesOptions.ThreeDCheckBoxes = true;
        }

        private void FillDoorTypesOptions()
        {
            DomainUpDown.DomainUpDownItemCollection doorCollection = this.doorSelector.Items;
            foreach (Door programDoor in this.program.HoleTypes.OfType<Door>())
            {
                doorCollection.Add(programDoor.Name);
            }
            this.doorSelector.Text = "Select DOOR";
            this.doorSelector.SelectedIndex = 0;
        }

        private void FillWindowTypesOptions()
        {
            DomainUpDown.DomainUpDownItemCollection windowCollection = this.windowSelector.Items;
            foreach (Window programWindow in this.program.HoleTypes.OfType<Window>())
            {
                windowCollection.Add(programWindow.Name);
            }
            this.windowSelector.Text = "Select WINDOW";
            this.windowSelector.SelectedIndex = 0;
        }

        public bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT ChartDrawing", MessageBoxButtons.YesNo);
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

        public void ChangeWindowForm(Form previousForm, Form newForm) {
            previousForm.Visible = false;
            newForm.Show();
        }

        private void ChartDrawing_FormClosing(object sender, FormClosingEventArgs e) {
            if (!ClosingProtocol()) {
                e.Cancel = true;
            }
        }

        private void CheckIfChartEmpty()
        {
            if (this.drawingChart.IsEmpty())
            {
                throw new ChartEmptyException();
            }
        }

        private void ConfirmChanges_Click(object sender, EventArgs e) {
            try
            {
                CheckIfChartEmpty();
                if (!this.program.IsChartNotYetRegistered(this.drawingChart) && !this.drawingChart.IsEmpty())
                {
                    this.program.Charts[this.program.Charts.IndexOf(this.drawingChart)] = this.drawingChart;
                    currentUser.AddChartsHelped(ref this.program);

                    ChartDataAccess chartContext = new ChartDataAccess();
                    chartContext.ModifyElementsToChart(this.drawingChart, this.drawingChart.Elements);
                    //chartContext.AddMoneyToChart(this.drawingChart, this.drawingChart.Money);
                    chartContext.SaveChanges();

                    MessageBox.Show("Changes SAVED !!!");
                    this.previousForm.ChangeToPreviousForm(this);
                }
                if (this.program.IsChartNotYetRegistered(this.drawingChart) && !this.drawingChart.IsEmpty())
                {
                    this.program.Charts.Add(this.drawingChart);
                    currentUser.AddChartsHelped(ref this.program);
                    currentUser.AddClientsHelped(ref this.program);

                    ChartDataAccess chartContext = new ChartDataAccess();
                    chartContext.AddElementsToChart(this.drawingChart, this.drawingChart.Elements);
                    chartContext.AddMoneyToChart(this.drawingChart, this.drawingChart.Money);
                    chartContext.SaveChanges();

                    MessageBox.Show("New Chart SAVED!!!");
                    this.previousForm.ChangeToPreviousForm(this);
                }
            }
            catch (ChartEmptyException)
            {
                MessageBox.Show("Cannot Save Changes because there is no element in Chart");
            }
            
        }

        private void Help_Click(object sender, EventArgs e) {
            MessageBox.Show("Create your Chart by Drawing Lines and selecting Holes. \nRemove Lines and " +
                "Holes by selecting the corresponding Button followed by the Figure you want to Remove." +
                "\nNOTHING COULD BE FUNNIER!");
        }

        private void ActivateDesactivateHole(Graphics holeGraphic, ref bool condition) {
            Pen activationFormat = new Pen(Color.Blue, 2);
            Pen desactivationFormat = new Pen(Color.White, 2);
            Rectangle selectedBorder = new Rectangle(0, 0, 90, 90);
            if (condition) {
                condition = false;
                holeGraphic.DrawRectangle(desactivationFormat, selectedBorder);
            } else {
                condition = true;
                holeGraphic.DrawRectangle(activationFormat, selectedBorder);
            }
        }

        private void Door_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (this.doorSelector.SelectedIndex != -1)
            {
                ActivateDesactivateHole(this.doorGraphic, ref this.isDoorSelected);
                this.isWindowSelected = false;
                this.isColumnSelected = false;
                Pen doorFormatOff = new Pen(Color.White, 2);
                Rectangle doorBorder = new Rectangle(0, 0, 90, 90);
                this.windowGraphic.DrawRectangle(doorFormatOff, doorBorder);
                this.columnGraphic.DrawRectangle(doorFormatOff, doorBorder);
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (this.windowSelector.SelectedIndex != -1)
            {
                ActivateDesactivateHole(this.windowGraphic, ref this.isWindowSelected);
                this.isDoorSelected = false;
                this.isColumnSelected = false;
                Pen windowsFormatOff = new Pen(Color.White, 2);
                Rectangle windowBorder = new Rectangle(0, 0, 90, 90);
                this.doorGraphic.DrawRectangle(windowsFormatOff, windowBorder);
                this.columnGraphic.DrawRectangle(windowsFormatOff, windowBorder);
            }
        }

        private void Column_MouseDoubleClick(object sender, MouseEventArgs e) {
            ActivateDesactivateHole(this.columnGraphic, ref this.isColumnSelected);
            this.isDoorSelected = false;
            this.isWindowSelected = false;
            Pen columnFormatOff = new Pen(Color.White, 2);
            Rectangle columnBorder = new Rectangle(0, 0, 90, 90);
            this.doorGraphic.DrawRectangle(columnFormatOff, columnBorder);
            this.windowGraphic.DrawRectangle(columnFormatOff, columnBorder);
        }

        private void ChartDraw_Paint(object sender, PaintEventArgs e) {
            this.drawingChart.DrawGrid(ref this.chartGraphic, this.differentStylesOptions.SelectedIndex);
            this.drawingChart.Elements = this.drawingChart.SortElements();
            this.InitializeHoles();
            this.door.Refresh();
            this.window.Refresh();
            this.column.Refresh();
            this.drawingChart.DrawElements(ref this.chartGraphic);
            this.CalculateChartMoney();
        }

        private void CalculateChartMoney() {
            double[] costAndPrice = this.program.CalculateCostAndPrice(this.drawingChart);
            this.currentCost.Text = "" + costAndPrice[0];
            double earnings = costAndPrice[1] - costAndPrice[0];
            this.currentEarnings.Text = "" + earnings;
        }

        private void Door_Paint(object sender, PaintEventArgs e) {
            this.doorGraphic.Clear(Color.White);
            this.doorChosen.Location.X = 50;
            this.doorChosen.Location.Y = 45;
            this.doorChosen.Draw(ref this.doorGraphic);
            this.DrawHelpersOfDoor();
        }


        private void Window_Paint(object sender, PaintEventArgs e) {
            this.windowGraphic.Clear(Color.White);
            this.windowChosen.Location.X = 45;
            this.windowChosen.Location.Y = 45;
            this.windowChosen.Draw(ref this.windowGraphic);
            this.DrawHelpersOfWindow();
        }

        private void DrawHelperLines(ref Graphics graphUsed, Pen[] linesFormats)
        {
            Point center = new Point(70, 10);
            Point horizontalRight = new Point(80, 10);
            Point horizontalLeft = new Point(60, 10);
            Point verticalUp = new Point(70, 0);
            Point verticalDown = new Point(70, 20);
            graphUsed.DrawLine(linesFormats[0], center, horizontalRight);
            graphUsed.DrawLine(linesFormats[1], center, verticalUp);
            graphUsed.DrawLine(linesFormats[2], center, horizontalLeft);
            graphUsed.DrawLine(linesFormats[3], center, verticalDown);
        }

        private void DrawHelpersOfDoor() {
            Pen lineHelperFormat = new Pen(Color.Gray, 2);
            Pen lineSelectedFormat = new Pen(Color.Orange, 2);

            if (this.doorChosen.OrientationDoor == ConstantsDoor.HORIZONTAL_RIGHT_ROTATION) {
                Pen[] linesFormat = { lineSelectedFormat, lineHelperFormat, lineHelperFormat, lineHelperFormat };
                DrawHelperLines(ref this.doorGraphic, linesFormat);
            }
            if (this.doorChosen.OrientationDoor == ConstantsDoor.VERTICAL_UP_ROTATION) {
                Pen[] linesFormat = { lineHelperFormat, lineSelectedFormat, lineHelperFormat, lineHelperFormat };
                DrawHelperLines(ref this.doorGraphic, linesFormat);
            }
            if (this.doorChosen.OrientationDoor == ConstantsDoor.HORIZONTAL_LEFT_ROTATION) {
                Pen[] linesFormat = { lineHelperFormat, lineHelperFormat, lineSelectedFormat, lineHelperFormat };
                DrawHelperLines(ref this.doorGraphic, linesFormat);
            }
            if (this.doorChosen.OrientationDoor == ConstantsDoor.VERTICAL_DOWN_ROTATION) {
                Pen[] linesFormat = { lineHelperFormat, lineHelperFormat, lineHelperFormat, lineSelectedFormat };
                DrawHelperLines(ref this.doorGraphic, linesFormat);
            }
        }

        private void DrawHelpersOfWindow() {
            Pen lineHelperFormat = new Pen(Color.Gray, 2);
            Pen lineSelectedFormat = new Pen(Color.Orange, 2);
            if (this.windowChosen.OrientationWindow == ConstantsWindow.HORIZONTAL_ORIENTATION) {
                Pen[] linesFormats = { lineSelectedFormat, lineHelperFormat, lineSelectedFormat, lineHelperFormat };
                DrawHelperLines(ref this.windowGraphic, linesFormats);
            }
            if (this.windowChosen.OrientationWindow == ConstantsWindow.VERTICAL_ORIENTATION) {
                Pen[] linesFormats = { lineHelperFormat, lineSelectedFormat, lineHelperFormat, lineSelectedFormat };
                DrawHelperLines(ref this.windowGraphic, linesFormats);
            }
        }

        private void Column_Paint(object sender, PaintEventArgs e) {
            Column columnForLegend = new Column(new Point(45,45));
            columnForLegend.Draw(ref this.columnGraphic);
        }

        private void RemoveLine_Click(object sender, EventArgs e) {
            if (this.isRemoveLineSelected) {
                this.isRemoveLineSelected = false;
                this.removeLine.BackColor = Color.Blue;
            } else {
                this.isRemoveLineSelected = true;
                this.isRemoveHoleSelected = false;
                this.removeLine.BackColor = Color.Black;
                this.removeHole.BackColor = Color.Green;
            }
        }

        private void RemoveHole_Click(object sender, EventArgs e) {
            if (this.isRemoveHoleSelected) {
                this.isRemoveHoleSelected = false;
                this.removeHole.BackColor = Color.Green;
            } else {
                this.isRemoveHoleSelected = true;
                this.isRemoveLineSelected = false;
                this.removeHole.BackColor = Color.Black;
                this.removeLine.BackColor = Color.Blue;
            }
        }

        private void ChartDraw_MouseDown(object sender, MouseEventArgs e) {
                this.initialPoint = e.Location;
        }

        private void ChartDraw_MouseUp(object sender, MouseEventArgs e) {
            Wall wallSelected = new Wall(new Point[] { new Point(initialPoint.Value.X,initialPoint.Value.Y), e.Location });
            Point eventHole = this.doorChosen.GetAppropiateLocation(e.Location);
            if (this.isRemoveHoleSelected && (!this.drawingChart.IsDoorNotYetRegistered(new Door(eventHole)))){
                this.drawingChart.Elements.Remove(this.drawingChart.Elements.Find(x => x.Equals(new Door(eventHole))));
                this.isChartModified = true;
            }
            if(this.isRemoveHoleSelected && !this.drawingChart.IsWindowNotYetRegistered(new Window(eventHole))) {
                this.drawingChart.Elements.Remove(this.drawingChart.Elements.Find(x => x.Equals(new Window(eventHole))));
                this.isChartModified = true;
            }
            if (this.isRemoveHoleSelected && !this.drawingChart.IsColumnNotYetRegistered(new Column(eventHole))) {
                this.drawingChart.Elements.Remove(this.drawingChart.Elements.Find(x => x.Equals(new Column(eventHole))));
                this.isChartModified = true;
            }
            if (this.isRemoveLineSelected && !this.drawingChart.IsWallNotYetRegistered(wallSelected)) {
                this.RemoveLineAndHoles(wallSelected);
                this.isChartModified = true;
            }
            if (!this.isRemoveLineSelected && wallSelected.IsInSameLine() && this.drawingChart.IsWallWellRegistered(wallSelected) 
                && !wallSelected.IsNullLength() && !this.drawingChart.IsHoleInBetween(wallSelected) && NoColumnOnBordersOfWall(wallSelected)) {
                this.WallProcedure(wallSelected);
                this.isChartModified = true;
            }
            this.chartDraw.Refresh();
        }

        private void RemoveLineAndHoles(Wall wallSelected) {
            this.drawingChart.RemoveWall(this.drawingChart.GetWallFromList(wallSelected));
            this.drawingChart.EliminateBeams(wallSelected);
            this.drawingChart.EliminateHoles(wallSelected);
        }

        private bool NoColumnOnBordersOfWall(Wall wallSelected) {
            Point wallSelectedCoordinatesOrigin = new Point(wallSelected.Coordinates.OriginX, wallSelected.Coordinates.OriginY);
            Point wallSelectedCoordinatesDestination = new Point(wallSelected.Coordinates.DestinationX, wallSelected.Coordinates.DestinationY);
            return this.drawingChart.IsColumnNotYetRegistered(new Column(wallSelectedCoordinatesOrigin)) 
                && this.drawingChart.IsColumnNotYetRegistered(new Column(wallSelectedCoordinatesDestination));
        }

        private void WallProcedure(Wall wallSelected) {
            Point wallSelectedCoordinatesOrigin = new Point(wallSelected.Coordinates.OriginX, wallSelected.Coordinates.OriginY);
            Point wallSelectedCoordinatesDestination = new Point(wallSelected.Coordinates.DestinationX, wallSelected.Coordinates.DestinationY);
            Beam originBeam = new Beam(wallSelectedCoordinatesOrigin);
            Beam destinationBeam = new Beam(wallSelectedCoordinatesDestination);
            this.drawingChart.AddBeamsDueToLength(wallSelected);
            this.drawingChart.IsBeamToChartAddable(originBeam);
            this.drawingChart.IsBeamToChartAddable(destinationBeam);
            this.drawingChart.IsIntersection();
        }

        private void RotateDoor_Click(object sender, EventArgs e) {
            this.doorChosen.RotateDoor();
            this.door.Refresh();
        }

        private void RotateWindow_Click(object sender, EventArgs e) {
            this.windowChosen.RotateWindow();
            this.window.Refresh();
        }

        private void Clear_Click(object sender, EventArgs e) {
            DialogResult userWish = MessageBox.Show("Want to Start Fresh?", "CLEAR CHART", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                this.drawingChart.Elements.Clear();
                this.isChartModified = true;
                this.chartDraw.Refresh();
            }
        }

        private void BackOption_Click(object sender, EventArgs e) {
            if (this.isChartModified) {
                this.previousForm.AskArchitectToSignChartOrDefault(this, this.drawingChart);
            } else {
                DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back? All your progress will be lost!", "BACK", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.previousForm.ChangeToPreviousForm(this);
                }
            }
        }

        private void ChartDraw_MouseClick(object sender, MouseEventArgs e) {

            Hole holeToDraw;
            if (this.isDoorSelected) {
                Point eventDoor = this.doorChosen.GetAppropiateLocation(e.Location);
                holeToDraw = this.program.GetHoleFromHoleTypes((String)this.doorSelector.Items[this.doorSelector.SelectedIndex]);
                Door doorToDraw = new Door(eventDoor);
                doorToDraw.OrientationDoor = this.doorChosen.OrientationDoor;
                doorToDraw.GetDoorFromHole(holeToDraw);
                this.CheckDoor(doorToDraw);
            }
            if (this.isWindowSelected) {
                Point eventWindow = this.windowChosen.GetAppropiateLocation(e.Location);
                holeToDraw = this.program.GetHoleFromHoleTypes((String)this.windowSelector.Items[this.windowSelector.SelectedIndex]);
                Window windowToDraw = new Window(eventWindow);
                windowToDraw.OrientationWindow = this.windowChosen.OrientationWindow;
                windowToDraw.GetWindowFromHole(holeToDraw);
                this.CheckWindow(windowToDraw);
            }
            if (this.isColumnSelected) {
                Column columnChosen = new Column(new Point(0, 0));
                Point eventColumn = columnChosen.GetAppropiateLocation(e.Location);
                columnChosen.Location.X = eventColumn.X;
                columnChosen.Location.Y = eventColumn.Y;
                this.CheckColumn(columnChosen);
            }
            
        }

        private void CheckDoor(Door doorToDraw) {
            Point doorLocation = new Point(doorToDraw.Location.X, doorToDraw.Location.Y);
            bool isDoorCorrect = this.drawingChart.IsPointOnChart(doorLocation) && !this.drawingChart.IsPointOnHole(doorToDraw.GetBorderPoints()[0]) && !this.drawingChart.IsPointOnHole(doorToDraw.GetBorderPoints()[1]);
            bool isSmallDoorCorrect = this.drawingChart.IsBeamNotYetRegistered(new Beam(doorLocation)) && this.drawingChart.IsWindowNotYetRegistered(new Window(doorLocation));
            bool isMediumDoorCorrect = isSmallDoorCorrect && this.drawingChart.IsDoorAvailable(doorToDraw, 1) && this.drawingChart.IsBeamNotYetRegisteredNearDoor(doorToDraw) && this.drawingChart.IsWindowNotYetRegisteredNearDoor(doorToDraw, 1);
            bool isBigDoorCorrect = isMediumDoorCorrect && this.drawingChart.IsDoorAvailable(doorToDraw, 2) && this.drawingChart.IsWindowNotYetRegisteredNearDoor(doorToDraw, 2) && this.drawingChart.IsNoBigDoorInSurroundingsOfDoor(doorToDraw, 2, 2) && (((doorToDraw.OrientationDoor==1 || doorToDraw.OrientationDoor==3) && this.drawingChart.IsNoBigDoorInSurroundingsOfDoor(doorToDraw, 3,2)) || ((doorToDraw.OrientationDoor == 2 || doorToDraw.OrientationDoor == 4) && this.drawingChart.IsNoBigDoorInSurroundingsOfDoor(doorToDraw, 2, 3)));

            if (this.IsCheckCorrect(doorToDraw.IsSmallHole() && isDoorCorrect && isSmallDoorCorrect, ref this.isDoorSelected)) {
                this.DrawDoor(doorToDraw);
            }

            if (this.IsCheckCorrect(doorToDraw.IsMediumHole() && isDoorCorrect && isMediumDoorCorrect, ref this.isDoorSelected)) {
                this.DrawDoor(doorToDraw);
            }

            if (this.IsCheckCorrect(doorToDraw.IsBigHole() && isDoorCorrect && isBigDoorCorrect, ref this.isDoorSelected)) {
                this.DrawDoor(doorToDraw);
            }

        }

        private void DrawDoor(Door doorToDraw) {
            this.drawingChart.AddDoor(doorToDraw);
            this.door.Refresh();
        }

        private void CheckWindow(Window windowToDraw) {
            Point windowLocation = new Point(windowToDraw.Location.X, windowToDraw.Location.Y);
            bool isWindowCorrect = this.drawingChart.IsPointOnChart(windowLocation) && !this.drawingChart.IsPointOnHole(windowToDraw.GetBorderPoints()[0]) && !this.drawingChart.IsPointOnHole(windowToDraw.GetBorderPoints()[1]);
            bool isSmallWindowCorrect = this.drawingChart.IsBeamNotYetRegistered(new Beam(windowLocation)) && this.drawingChart.IsDoorNotYetRegistered(new Door(windowLocation));
            bool isMediumWindowCorrect = isSmallWindowCorrect && this.drawingChart.IsWindowAvailable(windowToDraw, 1) && this.drawingChart.IsBeamNotYetRegisteredNearWindow(windowToDraw, 1) && this.drawingChart.IsDoorNotYetRegisteredNearWindow(windowToDraw, 1);
            bool isBigWindowCorrect = isMediumWindowCorrect && this.drawingChart.IsWindowAvailable(windowToDraw, 2) && this.drawingChart.IsBeamNotYetRegisteredNearWindow(windowToDraw, 2) && this.drawingChart.IsDoorNotYetRegisteredNearWindow(windowToDraw, 2);

            if (this.IsCheckCorrect(windowToDraw.IsSmallHole() && isWindowCorrect && isSmallWindowCorrect, ref this.isWindowSelected)) {
                this.DrawWindow(windowToDraw);
            }

            if (this.IsCheckCorrect(windowToDraw.IsMediumHole() && isWindowCorrect && isMediumWindowCorrect, ref this.isWindowSelected)) {
                this.DrawWindow(windowToDraw);
            }

            if (this.IsCheckCorrect(windowToDraw.IsBigHole() && isWindowCorrect && isBigWindowCorrect, ref this.isWindowSelected)) {
                this.DrawWindow(windowToDraw);
            }

        }

        private void DrawWindow(Window windowToDraw) {
            this.drawingChart.AddWindow(windowToDraw);
            this.window.Refresh();
        }

        private void CheckColumn(Column columnChosen) {
            Point columnLocation = new Point(columnChosen.Location.X, columnChosen.Location.Y);
            bool oneThing = this.drawingChart.IsColumnAvailable(columnChosen);
            bool otherThing = !this.drawingChart.IsPointOnHole(columnLocation);
            bool isColumnCorrect = oneThing && otherThing;

            if (this.IsCheckCorrect(isColumnCorrect, ref this.isColumnSelected)) {
                this.drawingChart.AddColumn(columnChosen);
                this.column.Refresh();
            }
        }

        private bool IsCheckCorrect (bool conditionToCheck, ref bool conditionToChange) {
            if (conditionToCheck) {
                conditionToChange = false;
                this.isChartModified = true;
            }
            return conditionToCheck;
        }

        private void DifferentStylesOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = this.differentStylesOptions.SelectedIndex;
            if (selectedItem == -1) {
                this.differentStylesOptions.SelectedIndex = 0;
                this.differentStylesOptions.SetItemChecked(0, true);
            }
            if (selectedItem == 0) {
                this.differentStylesOptions.SetItemChecked(1, false);
                this.differentStylesOptions.SetItemChecked(2, false);
            }
            if (selectedItem == 1) {
                this.differentStylesOptions.SetItemChecked(0, false);
                this.differentStylesOptions.SetItemChecked(2, false);
            }
            if (selectedItem == 2) {
                this.differentStylesOptions.SetItemChecked(0, false);
                this.differentStylesOptions.SetItemChecked(1, false);
            }
            this.chartDraw.Refresh();
        }
    }
}
