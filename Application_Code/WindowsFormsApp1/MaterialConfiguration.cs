using Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class MaterialConfiguration : Form
    {

        private SketchItApp program;
        public MaterialConfiguration(SketchItApp programContinuation)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.InitializeWindow();
        }

        public void InitializeWindow()
        {
            this.SetCostData();
            this.SetPriceData();
            this.FillDoorTypesOptions();
            this.FillWindowTypesOptions();
        }

        private void FillDoorTypesOptions() {
            DomainUpDown.DomainUpDownItemCollection doorCollection = this.doorSelector.Items;
            foreach (Door programDoor in this.program.HoleTypes.OfType<Door>()) {
                doorCollection.Add(programDoor.Name);
            }
            this.doorSelector.Text = "Select DOOR";
        }

        private void FillWindowTypesOptions() {
                DomainUpDown.DomainUpDownItemCollection windowCollection = this.windowSelector.Items;
                foreach (Window programWindow in this.program.HoleTypes.OfType<Window>())
                {
                    windowCollection.Add(programWindow.Name);
                }
                this.windowSelector.Text = "Select WINDOW";
        }

        private void SetCostData()
        {
            this.wallCostTyped.Text = "" + this.program.elementsMoney.CostWall;
            this.beamCostTyped.Text = "" + this.program.elementsMoney.CostBeam;
            this.doorCostTyped.Text = "" + this.program.elementsMoney.CostDoor;
            this.windowCostTyped.Text = "" + this.program.elementsMoney.CostWindow;
            this.columnCostTyped.Text = "" + this.program.elementsMoney.CostColumn;
            this.currentWallCost.Text = "Current: " + this.program.elementsMoney.CostWall;
            this.currentBeamCost.Text = "Current: " + this.program.elementsMoney.CostBeam;
            this.currentDoorCost.Text = "Current: " + this.program.elementsMoney.CostDoor;
            this.currentWindowCost.Text = "Current: " + this.program.elementsMoney.CostWindow;
            this.currentColumnCost.Text = "Current: " + this.program.elementsMoney.CostColumn;
        }

        private void SetPriceData()
        {
            this.wallPriceTyped.Text = "" + this.program.elementsMoney.PriceWall;
            this.beamPriceTyped.Text = "" + this.program.elementsMoney.PriceBeam;
            this.doorPriceTyped.Text = "" + this.program.elementsMoney.PriceDoor;
            this.windowPriceTyped.Text = "" + this.program.elementsMoney.PriceWindow;
            this.columnPriceTyped.Text = "" + this.program.elementsMoney.PriceColumn;
            this.currentWallPrice.Text = "Current: " + this.program.elementsMoney.PriceWall;
            this.currentBeamPrice.Text = "Current: " + this.program.elementsMoney.PriceBeam;
            this.currentDoorPrice.Text = "Current: " + this.program.elementsMoney.PriceDoor;
            this.currentWindowPrice.Text = "Current: " + this.program.elementsMoney.PriceWindow;
            this.currentColumnPrice.Text = "Current: " + this.program.elementsMoney.PriceColumn;
        }

        public void ChangeWindowForm(Form previousForm, Form nextForm)
        {
            previousForm.Visible = false;
            nextForm.Show();
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

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.ConfirmTotalCost() && this.ConfirmTotalPrice() && this.doorSelector.SelectedIndex!=-1 && this.windowSelector.SelectedIndex!=-1)
            {
                this.ChangeDoorTypeMoney(double.Parse(this.doorCostTyped.Text), double.Parse(this.doorPriceTyped.Text));
                this.ChangeWindowTypeMoney(double.Parse(this.windowCostTyped.Text), double.Parse(this.windowPriceTyped.Text));
                MessageBox.Show("Cost & Price SUCCESFULLY Changed!");
                this.program.UpdateChartsData();
                ChangeWindowForm(this, new MenuAdmin(this.program));
            }
            else
            {
                MessageBox.Show("Please, check the correct entry of Numbers and the correct selection of Both Hole Types", "ERROR");
            }
        }

        private void ChangeDoorTypeMoney(double newDoorCost, double newDoorPrice)
        {
            this.program.GetHoleFromHoleTypes((String)this.doorSelector.Items[this.doorSelector.SelectedIndex]).Money.Cost = newDoorCost;
            this.program.GetHoleFromHoleTypes((String)this.doorSelector.Items[this.doorSelector.SelectedIndex]).Money.Price = newDoorPrice;
        }

        private void ChangeWindowTypeMoney(double newWindowCost, double newWindowPrice)
        {
            this.program.GetHoleFromHoleTypes((String)this.windowSelector.Items[this.windowSelector.SelectedIndex]).Money.Cost = newWindowCost;
            this.program.GetHoleFromHoleTypes((String)this.windowSelector.Items[this.windowSelector.SelectedIndex]).Money.Price = newWindowPrice;
        }

        private bool ConfirmTotalCost()
        {
            bool costWellSetWall, costWellSetBeam, costWellSetDoor, costWellSetWindow, costWellSetColumn;
            double costOfWall = 0, costOfBeam = 0, costOfDoor = 0, costOfWindow = 0, costOfColumn = 0;
            costWellSetWall = this.ConfirmCost(this.wallCostTyped.Text, ref costOfWall);
            costWellSetBeam = this.ConfirmCost(this.beamCostTyped.Text, ref costOfBeam);
            costWellSetDoor = this.ConfirmCost(this.doorCostTyped.Text, ref costOfDoor);
            costWellSetWindow = this.ConfirmCost(this.windowCostTyped.Text, ref costOfWindow);
            costWellSetColumn = this.ConfirmCost(this.columnCostTyped.Text, ref costOfColumn);
            bool costWellSet = costWellSetWall && costWellSetBeam && costWellSetDoor && costWellSetWindow && costWellSetColumn;
            if (costWellSet) {
                this.program.elementsMoney.CostWall = costOfWall;
                this.program.elementsMoney.CostBeam = costOfBeam;
                this.program.elementsMoney.CostDoor = costOfDoor;
                this.program.elementsMoney.CostWindow = costOfWindow;
                this.program.elementsMoney.CostColumn = costOfColumn;
            }
            return costWellSet;
        }

        private bool ConfirmCost(String costTyped, ref double costStorage)
        {
            return double.TryParse(costTyped, out costStorage);
        }

        private bool ConfirmTotalPrice()
        {
            bool priceWellSetWall, priceWellSetBeam, priceWellSetDoor, priceWellSetWindow, priceWellSetColumn;
            double priceOfWall = 0, priceOfBeam = 0, priceOfDoor = 0, priceOfWindow = 0, priceOfColumn = 0;
            priceWellSetWall = this.ConfirmPrice(this.wallPriceTyped.Text, ref priceOfWall);
            priceWellSetBeam = this.ConfirmPrice(this.beamPriceTyped.Text, ref priceOfBeam);
            priceWellSetDoor = this.ConfirmPrice(this.doorPriceTyped.Text, ref priceOfDoor);
            priceWellSetWindow = this.ConfirmPrice(this.windowPriceTyped.Text, ref priceOfWindow);
            priceWellSetColumn = this.ConfirmPrice(this.columnPriceTyped.Text, ref priceOfColumn);
            bool priceWellSet = priceWellSetWall && priceWellSetBeam && priceWellSetDoor && priceWellSetWindow && priceWellSetColumn;
            if (priceWellSet) {
                this.program.elementsMoney.PriceWall = priceOfWall;
                this.program.elementsMoney.PriceBeam = priceOfBeam;
                this.program.elementsMoney.PriceDoor = priceOfDoor;
                this.program.elementsMoney.PriceWindow = priceOfWindow;
                this.program.elementsMoney.PriceColumn = priceOfColumn;
            }
            return priceWellSet;
        }

        private bool ConfirmPrice(String priceTyped, ref double priceStorage)
        {
            return double.TryParse(priceTyped, out priceStorage);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modify every Material's Costs and Prices you desire", "MATERIAL CONFIGURATION");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new MenuAdmin(this.program));
            }
        }

        private void MaterialConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void DoorSelector_SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.doorSelector.SelectedIndex != -1) {
                Hole doorSelected = new Door(new Point(0, 0));
                doorSelected = this.program.GetHoleFromHoleTypes((String)doorSelector.Items[this.doorSelector.SelectedIndex]);
                this.doorCostTyped.Text = "" + doorSelected.Money.Cost;
                this.doorPriceTyped.Text = "" + doorSelected.Money.Price;
                this.currentDoorCost.Text = "Current: " + doorSelected.Money.Cost;
                this.currentDoorPrice.Text = "Current: " + doorSelected.Money.Price;
            }
        }

        private void WindowSelector_SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.windowSelector.SelectedIndex != -1) {
                Hole windowSelected = new Window(new Point(0, 0));
                windowSelected = this.program.GetHoleFromHoleTypes((String)windowSelector.Items[this.windowSelector.SelectedIndex]);
                this.windowCostTyped.Text = "" + windowSelected.Money.Cost;
                this.windowPriceTyped.Text = "" + windowSelected.Money.Price;
                this.currentWindowCost.Text = "Current: " + windowSelected.Money.Cost;
                this.currentWindowPrice.Text = "Current: " + windowSelected.Money.Price;
            }
        }
    }
}
